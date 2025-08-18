/// <summary>
/// HEL Lexical Analyzer - converts HEL equation text into a stream of tokens for parsing.
/// The lexer scans input text and identifies numbers, variables, operators, keywords, and other language elements.
/// Supports variable prefixes for different contexts (LHS vs RHS) and handles comments and embedded content.
/// </summary>
/// <remarks>
/// The lexer handles several token types:
/// - Numbers (including negative numbers and decimals)
/// - Variables with prefixes (S_, T_, Z_, etc.) for stats, buffs, and other game elements
/// - Operators (+, -, *, /, ^, ==, !=, &lt;=, &gt;=, &lt;, &gt;)
/// - Keywords (RAND, CEIL, FLOOR, ROUND, MIN, MAX, AND, OR, NOT, TRUE, FALSE)
/// - Assignment operators (=)
/// - Statement terminators (;)
/// - Comments (--)
/// - Embedded content (#!number)
/// 
/// NOTE: VAL and VAL2 constants are substituted with their actual values before lexing.
/// </remarks>
public class HELLexer
{
    /// <summary>
    /// The input string containing HEL equations to be tokenized.
    /// </summary>
    private string input;
    
    /// <summary>
    /// Current character position in the input string.
    /// </summary>
    private int position;
    
    /// <summary>
    /// Total length of the input string.
    /// </summary>
    private int length;
    
    /// <summary>
    /// The current character being examined during tokenization.
    /// </summary>
    private char currentChar;

    /// <summary>
    /// List of recognized keywords in the HEL language.
    /// These are either constants (e.g., TRUE, FALSE) or function names (e.g., RAND, MIN, MAX).
    /// </summary>
    static List<string> KeywordList = new List<string> { 
        "RAND", 
        "CEIL", 
        "FLOOR",
        "ROUND",
        "MIN",
        "MAX",
        "AND",
        "OR",
        "NOT",
        "TRUE",
        "FALSE"
        };

    /// <summary>
    /// Variable prefixes allowed on the left-hand side of assignments.
    /// Represents different categories of assignable game elements.
    /// </summary>
    static string LHSprefix = "bamzuBAMZU";

    /// <summary>
    /// Variable prefixes allowed on the right-hand side of expressions.
    /// Represents different categories of readable game elements including stats, temps, etc.
    /// </summary>
    static string RHSprefix = "stzubamSTZUBAM";

    /// <summary>
    /// Initializes a new instance of the HELLexer class with the specified input text.
    /// Sets up the lexer state and positions at the first character.
    /// </summary>
    /// <param name="input">The HEL equation text to be tokenized</param>
    public HELLexer(string input)
    {
        this.input = input;
        this.position = -1;
        this.length = input.Length;
        Advance();
    }

    /// <summary>
    /// Advances to the next character in the input stream.
    /// Sets currentChar to '\0' when reaching the end of input.
    /// </summary>
    private void Advance()
    {
        position++;
        if (position < length)
            currentChar = input[position];
        else
            currentChar = '\0';
    }

    /// <summary>
    /// Looks ahead to the next character in the input without advancing the position.
    /// Used to handle multi-character operators and tokens.
    /// </summary>
    /// <returns>The next character, or '\0' if at the end of input</returns>
    private char Peek()
    {
        int peekPos = position + 1;
        if (peekPos < length)
            return input[peekPos];
        else
            return '\0';
    }

    /// <summary>
    /// Converts the input text into a list of tokens for parsing.
    /// Handles all HEL language elements including numbers, variables, operators, keywords, and special tokens.
    /// Tracks LHS/RHS context to properly classify variables based on assignment position.
    /// </summary>
    /// <returns>A list of tokens representing the parsed input, terminated with an EOF token</returns>
    /// <exception cref="Exception">Thrown when encountering invalid syntax or malformed tokens</exception>
    public List<Token> Tokenize()
    {
        List<Token> tokens = new List<Token>();
        #if MYDEBUG            
            int tokenCt = 0;
        #endif
 
        bool is_lhs = true;
 
        while (currentChar != '\0')
        {
            // WARNING: Order is importantin these if, else if clauses. For example,
            // we don't convert '=' until we've already convert longer tokens starting
            // with '=', like '==' and '=>'.
            if (char.IsWhiteSpace(currentChar))
            {
                Advance();
            }
            else if (currentChar == '-' && Peek() == '-')
            {
                // Comment
                Advance();
                Advance();
                while (currentChar != '\n' && currentChar != '\r' && currentChar != '\0')
                {
                    Advance();
                }
                tokens.Add(new Token(TokenType.Semicolon, ";", position)); // artificially added to close of any previous stmt
            }
            else if (currentChar == '#' && Peek() == '!')
            {
                // Embed
                Advance();
                Advance();
                if (!char.IsDigit(currentChar))
                {
                    throw new Exception($"Digit expected after \"#!\" in Embed token. '{currentChar}' seen instead.");
                }
                string number = ReadNumber();
                tokens.Add(new Token(TokenType.Embed, "#!"+number, position));
            }
            else if (currentChar == '=' && Peek() == '=')
            {
                tokens.Add(new Token(TokenType.Operator, "==", position));
                Advance();
                Advance();
            }
            else if (currentChar == '=')
            {
                is_lhs = false;
                tokens.Add(new Token(TokenType.Assign, "=", position));
                Advance();
            }
            else if (currentChar == '!' && Peek() == '=')
            {
                tokens.Add(new Token(TokenType.Assign, "!=", position));
                Advance();
                Advance();
            }
            else if (currentChar == ';')
            {
                is_lhs = true;
                tokens.Add(new Token(TokenType.Semicolon, ";", position));
                Advance();
            }
            else if (currentChar == '$')
            {
                tokens.Add(new Token(TokenType.EndOfLine, "$", position));
                Advance();
            }
            else if (currentChar == '<' && Peek() == '=')
            {
                tokens.Add(new Token(TokenType.Operator, "<=", position));
                Advance();
                Advance();
            }
            else if (currentChar == '>' && Peek() == '=')
            {
                tokens.Add(new Token(TokenType.Operator, ">=", position));
                Advance();
                Advance();
            }
            else if (currentChar == '+' || currentChar == '*' || currentChar == '/' || 
                     currentChar == '^' || currentChar == '<' || currentChar == '>')
            {
                tokens.Add(new Token(TokenType.Operator, currentChar.ToString(), position));
                Advance();
            }
            else if (currentChar == '-')
            {
                char nextChar = Peek();
               // if (nextChar == '-')
               // {
               //     // Comment
               //     Advance();
               //     Advance();
               //     while (currentChar != '\n' && currentChar != '\r' && currentChar != '\0')
               //     {
               //         Advance();
               //     }
               // }
               // else 
                if (char.IsDigit(nextChar))
                {
                    // Negative number
                    string number = ReadNumber();
                    tokens.Add(new Token(TokenType.Number, number, position));
                }
                else if (char.IsLetter(nextChar))
                {
                    // Negative RHS variable
                    Advance(); // consume '-'
                    string identifier = "-" + ReadIdentifier();
                    if (IsRHSVariable(identifier.Substring(1)))
                    {
                        tokens.Add(new Token(TokenType.RHSVariable, identifier, position));
                    }
                    else
                    {
                        tokens.Add(new Token(TokenType.Unknown, identifier, position));
                    }
                }
                else
                {
                    // Operator '-'
                    tokens.Add(new Token(TokenType.Operator, "-", position));
                    Advance();
                }
            }
            else if (char.IsLetter(currentChar))
            {
                string identifier = ReadIdentifier();
                string upperIdentifier = identifier.ToUpper();

                if (KeywordList.Contains(upperIdentifier)) //store all keywords in KeywordList
                   // upperIdentifier == "MAX" || upperIdentifier == "MIN" || upperIdentifier == "RAND" ||
                   // upperIdentifier == "CEIL" || upperIdentifier == "FLOOR")... and others added later
                {
                    tokens.Add(new Token(TokenType.Keyword, upperIdentifier, position));
                }
                else if (IsLHSVariable(identifier))
                {
                    if (is_lhs == false) 
                        tokens.Add(new Token(TokenType.RHSVariable, identifier, position));
                    else
                        tokens.Add(new Token(TokenType.LHSVariable, identifier, position));
                }
                else if (IsRHSVariable(identifier))
                {
                    if (is_lhs == false)
                        tokens.Add(new Token(TokenType.RHSVariable, identifier, position));
                    else
                        throw new Exception($"Variable '{identifier}'cannot be assigned to.");
                }
                else
                {
                    tokens.Add(new Token(TokenType.Unknown, identifier, position));
                }
            }
            else if (char.IsDigit(currentChar))
            {
                string number = ReadNumber();
                tokens.Add(new Token(TokenType.Number, number, position));
            }
            else
            {
                tokens.Add(new Token(TokenType.Unknown, currentChar.ToString(), position));
                Advance();
            }

            #if MYDEBUG                
                for (int i = tokenCt + 1; i <= tokens.Count; i++) {
                        Console.Write($"LEXER: ");
                        var j = tokens.Count - tokenCt;
                        tokens[^j].dump();
                }
                tokenCt = tokens.Count;
            #endif
        }

        tokens.Add(new Token(TokenType.EOF, "EOF", position));
        #if MYDEBUG            
            Console.Write($"LEXER: ");
            if (tokenCt > 0)
                tokens[^1].dump();
        #endif

        return tokens;
    }

    /// <summary>
    /// Reads an identifier (variable name or keyword) from the current position.
    /// Identifiers consist of letters, digits, and underscores.
    /// </summary>
    /// <returns>The complete identifier string</returns>
    private string ReadIdentifier()
    {
        System.Text.StringBuilder result = new System.Text.StringBuilder();
        while (char.IsLetterOrDigit(currentChar) || currentChar == '_')
        {
            result.Append(currentChar);
            Advance();
        }
        return result.ToString();
    }

    /// <summary>
    /// Reads a numeric literal from the current position.
    /// Supports integers and floating-point numbers, including negative values.
    /// </summary>
    /// <returns>The complete number as a string</returns>
    private string ReadNumber()
    {
        System.Text.StringBuilder result = new System.Text.StringBuilder();
        if (currentChar == '-')
        {
            result.Append(currentChar);
            Advance();
        }
        while (char.IsDigit(currentChar))
        {
            result.Append(currentChar);
            Advance();
        }
        if (currentChar == '.')
        {
            result.Append(currentChar);
            Advance();
            while (char.IsDigit(currentChar))
            {
                result.Append(currentChar);
                Advance();
            }
        }
        return result.ToString();
    }

    /// <summary>
    /// Determines if an identifier is a valid left-hand side variable.
    /// LHS variables can be assigned to and must have valid prefixes and format.
    /// </summary>
    /// <param name="identifier">The identifier to check</param>
    /// <returns>True if the identifier is a valid LHS variable, false otherwise</returns>
    private bool IsLHSVariable(string identifier)
    {
        if (identifier.Length >= 3 && identifier[1] == '_')
        {
            char firstChar = identifier[0];
            if (LHSprefix.IndexOf(firstChar) >= 0)
            {
                string rest = identifier.Substring(2);
                foreach (char c in rest)
                {
                    if (!char.IsLetter(c))
                        return false;
                }
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Determines if an identifier is a valid right-hand side variable.
    /// RHS variables can be read from and must have valid prefixes and format.
    /// </summary>
    /// <param name="identifier">The identifier to check</param>
    /// <returns>True if the identifier is a valid RHS variable, false otherwise</returns>
    private bool IsRHSVariable(string identifier)
    {
        if (identifier.Length >= 3 && identifier[1] == '_')
        {
            char firstChar = identifier[0];
            if (RHSprefix.IndexOf(firstChar) >= 0)
            {
                string rest = identifier.Substring(2);
                foreach (char c in rest)
                {
                    if (!char.IsLetter(c))
                        return false;
                }
                return true;
            }
        }
        return false;
    }
}
