using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.CompilerServices;

using Vertex = System.Tuple<int, int>;

/// <summary>
/// Defines the different types of tokens that can be recognized in HEL equations.
/// </summary>
public enum TokenType
{
    /// <summary>
    /// Numeric literal token (e.g., "3.14", "42").
    /// </summary>
    Number,
    
    /// <summary>
    /// Left-hand side variable token in assignments (e.g., "S_STRENGTH").
    /// </summary>
    LHSVariable,
    
    /// <summary>
    /// Right-hand side variable token in expressions (e.g., "S_HEALTH").
    /// </summary>
    RHSVariable,
    
    /// <summary>
    /// Mathematical operator token (e.g., "+", "-", "*", "/").
    /// </summary>
    Operator,
    
    /// <summary>
    /// Language keyword token (e.g., "IF", "THEN", "ELSE").
    /// </summary>
    Keyword,
    
    /// <summary>
    /// Assignment operator token ("=").
    /// </summary>
    Assign,
    
    /// <summary>
    /// Statement terminator token (";").
    /// </summary>
    Semicolon,
    
    /// <summary>
    /// End of line marker token.
    /// </summary>
    EndOfLine,
    
    /// <summary>
    /// End of file marker token.
    /// </summary>
    EOF,
    
    /// <summary>
    /// Embedded content token for special processing.
    /// </summary>
    Embed,
    
    /// <summary>
    /// Unrecognized or invalid token type.
    /// </summary>
    Unknown
}

/// <summary>
/// Represents a single token in a HEL equation with its type, value, and metadata.
/// Tokens are the basic building blocks of HEL expressions after lexical analysis.
/// </summary>
public class Token
{
    /// <summary>
    /// Gets or sets the type of the token (e.g., Number, LHSVariable, RHSVariable, etc.).
    /// </summary>
    public TokenType Type { get; set; }

    /// <summary>
    /// Gets or sets the raw string value of the token, converted to uppercase.
    /// </summary>
    public string Value { get; set; }

    /// <summary>
    /// Gets or sets the prefix extracted from the token's value (the part before the underscore).
    /// Used for variable tokens to identify their category (e.g., 'S' for stats, 'M' for mods).
    /// </summary>
    public char Prefix { get; set; }

    /// <summary>
    /// Gets or sets the variable name extracted from the token's value (the part after the underscore).
    /// Contains the actual variable identifier without the prefix.
    /// </summary>
    public string Variable { get; set; }

    /// <summary>
    /// Gets or sets the numeric value of the token if it represents a number.
    /// Only valid when Type is TokenType.Number.
    /// </summary>
    public float NumVal { get; set; }

    /// <summary>
    /// Gets or sets the position in the input string where the token was encountered.
    /// Used for error reporting and debugging.
    /// </summary>
    public int Position { get; set; }

    /// <summary>
    /// Initializes a new instance of the Token class with the specified type, value, and position.
    /// Automatically parses numeric values and extracts prefix/variable components from variable tokens.
    /// </summary>
    /// <param name="type">The type of the token</param>
    /// <param name="value">The string value of the token</param>
    /// <param name="position">The character position in the source where this token was found</param>
    /// <exception cref="Exception">Thrown when a token contains too many underscore characters</exception>
    public Token(TokenType type, string value, int position)
    {
        this.Type = type;
        this.Value = value.ToUpper();
        this.Position = position;
        this.Variable = "";
        if (type == TokenType.Number) {
            //Errors in the number are caught by the lexer, so no need to check for correctness here
            float.TryParse(value, out float floatValue);
            this.NumVal = floatValue;
        }
        string[] parts = this.Value.Split('_');
        if (parts.Length == 2) {
            this.Prefix = parts[0][0];
            this.Variable = parts[1];
        }
        else if (parts.Length > 2) {
            throw new Exception($"Too many '_' in token: {this.Value}");
        }
    }

    /// <summary>
    /// Encodes a mod ID into a comment token format.
    /// </summary>
    /// <param name="modid">The mod ID to encode</param>
    /// <returns>A string in the format "#!{modid}" for embedding mod references</returns>
    public static string EncodeComment(int modid)
    {
        return $"#!{modid}";
    }

    /// <summary>
    /// Decodes a mod ID from a comment token format.
    /// </summary>
    /// <param name="s">The comment token string to decode</param>
    /// <returns>The mod ID extracted from the comment token</returns>
    /// <exception cref="FormatException">Thrown when the string is not a valid comment token format</exception>
    public static int DecodeComment(string s)
    {
        if (!s.StartsWith("#!")) throw new FormatException("Invalid Comment Token");
        return int.Parse(s.Substring(2));
    }

    /// <summary>
    /// Outputs debug information about this token to the console.
    /// Displays the token's type, value, numeric value, and position.
    /// </summary>
    public void dump() {
        Console.WriteLine($"TOKEN Type:{this.Type} Value:{this.Value} NumVal:{this.NumVal} Position:{this.Position}");
    }
}

/// <summary>
/// Represents a complete statement in a HEL equation, consisting of tokens and evaluation context.
/// Statements are parsed assignment expressions or embedded content that modify game statistics.
/// </summary>
public class Statement
{
    /// <summary>
    /// Gets or sets the original index of the statement in the source input list.
    /// </summary>
    public int Index { get; set; }

    /// <summary>
    /// Gets or sets the list of tokens that comprise this statement.
    /// </summary>
    public List<Token> Tokens { get; set; }

    /// <summary>
    /// Stack used during expression evaluation to hold intermediate numeric results.
    /// </summary>
    public Stack<float> Values;

    /// <summary>
    /// Gets or sets the ID of the Mod (Equation) containing this statement.
    /// </summary>
    public int ModID;

    /// <summary>
    /// Gets or sets the index of the statement within a MOD equation.
    /// </summary>
    public int ModPos;

    /// <summary>
    /// Gets or sets the current parsing position index within the Tokens list (used in Interpreter).
    /// </summary>
    public int pos;

    /// <summary>
    /// Gets or sets the left-hand side variable token in assignment statements.
    /// This is the variable being assigned to.
    /// </summary>
    public Token? LHSVariable { get; set; }
    
    /// <summary>
    /// Gets or sets the list of right-hand side variable tokens referenced in the expression.
    /// These are the variables being read from to compute the assignment.
    /// </summary>
    public List<Token> RHSVariables { get; set; }


    /// <summary>
    /// Initializes a new instance of the Statement class with the specified parameters.
    /// Automatically identifies LHS and RHS variables based on token patterns.
    /// </summary>
    /// <param name="index">The original index of the statement in the source input list</param>
    /// <param name="tokens">The list of tokens that comprise this statement</param>
    /// <param name="modid">The ID of the mod containing this statement</param>
    /// <param name="modpos">The position index within the mod's equation</param>
    /// <exception cref="Exception">Thrown when the statement format is invalid</exception>
    public Statement(int index, List<Token> tokens, int modid, int modpos)
    {
        Index = index;
        Tokens = new List<Token>(tokens);
        Values = new Stack<float>();
        ModID = modid;
        ModPos = modpos;
        pos = 0;
        if (tokens.Count >= 3 && tokens[0].Type == TokenType.LHSVariable && tokens[1].Type == TokenType.Assign)
        {
            LHSVariable = tokens[0];
            RHSVariables = tokens.GetRange(2, tokens.Count - 2)
                                .Where(t => t.Type == TokenType.RHSVariable && t.Value.Contains('_'))
                                .ToList();
        }
        else if (tokens.Count == 1 && tokens[0].Type == TokenType.Embed)
        {
            LHSVariable = tokens[0];
            RHSVariables = tokens;  // Not really true. Just done to make things work
        }
        else
        {
            throw new Exception($"Invalid assignment statement at index {index}");
        }
    }

    /// <summary>
    /// Gets the vertex representation of this statement as a tuple of ModID and ModPos.
    /// Used for dependency graph construction and ordering.
    /// </summary>
    /// <returns>A Vertex tuple containing (ModID, ModPos)</returns>
    public Vertex GetVertex()
    {
        return new Vertex(ModID, ModPos);
    }

    /// <summary>
    /// Returns a string representation of this statement's vertex coordinates.
    /// </summary>
    /// <returns>A string in the format "(ModID,ModPos)"</returns>
    public string dumpVertex()
    {
        return dumpVertex(ModID, ModPos);
    }

    /// <summary>
    /// Returns a string representation of the specified vertex coordinates.
    /// </summary>
    /// <param name="modid">The mod ID</param>
    /// <param name="modpos">The position within the mod</param>
    /// <returns>A string in the format "(modid,modpos)"</returns>
    public static string dumpVertex(int modid, int modpos)
    {
        return $"({modid},{modpos})";
    }

    /// <summary>
    /// Returns a string representation of this statement by concatenating all token values.
    /// </summary>
    /// <returns>A space-separated string of token values</returns>
    public string dumpStr() 
    {
        var s = "";
        foreach (Token t in Tokens) {
            s += $" {t.Value}";
        }
        return s;
    }

    /// <summary>
    /// Outputs debug information about this statement to the console.
    /// Displays the statement as a concatenated string of token values.
    /// </summary>
    public void dump()
    {
        Console.WriteLine(dumpStr());
    }
}
