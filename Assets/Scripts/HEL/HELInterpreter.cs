//s#define MYDEBUG  //Uncomment line to output debug info to the console.

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using statsDictionary = System.Collections.Generic.Dictionary<string, Stat>;



/// <summary>
/// HEL Interpreter - executes parsed HEL statements to modify game statistics.
/// Uses a coefficient-based system to track and apply various types of stat modifications
/// including base changes, multipliers, additive bonuses, and range adjustments.
/// Handles dependency ordering and cycle resolution for complex mod interactions.
/// </summary>
/// <remarks>
/// The interpreter works with several coefficient types:
/// - S: Base stat values (starting values)
/// - B: Base additive modifiers  
/// - A: Absolute additive modifiers
/// - M: Multiplicative modifiers (percentage-based)
/// - Z: Minimum value adjustments
/// - U: Maximum value adjustments
/// - T: Temporary modifiers
/// 
/// The final stat calculation formula is:
/// result = Min(Max((S + B) * Max(0, 1 + M) + A, min + Z), max + U)
/// 
/// TODO: Correctly use S_ and B_, Handle T_ temporary modifiers, Verify mod equations
/// </remarks>
public class Interpreter
{
    /// <summary>
    /// Represents a set of coefficient values for different types of stat modifications.
    /// Each coefficient corresponds to a different way mods can affect a stat's final value.
    /// </summary>
    protected class Coefficient
    {
        /// <summary>Base additive modifier (B_ prefix)</summary>
        public float b { get; set; }
        
        /// <summary>Absolute additive modifier (A_ prefix)</summary>
        public float a { get; set; }
        
        /// <summary>Multiplicative modifier (M_ prefix)</summary>
        public float m { get; set; }
        
        /// <summary>Minimum value adjustment (Z_ prefix)</summary>
        public float z { get; set; }
        
        /// <summary>Maximum value adjustment (U_ prefix)</summary>
        public float u { get; set; }
        
        /// <summary>Base stat value (S_ prefix)</summary>
        public float s { get; set; }
        
        /// <summary>Temporary modifier (T_ prefix)</summary>
        public float t { get; set; }

        /// <summary>
        /// Initializes a new Coefficient with the specified base stat value and zeros for all modifiers.
        /// </summary>
        /// <param name="sValue">The base stat value to initialize the S coefficient with</param>
        public Coefficient(float sValue = 0.0f) 
        {
            s = sValue;  //sValue;
            b = 0.0f; //bValue;
            a = 0.0f; //aValue;
            m = 0.0f; //mValue;
            z = 0.0f; //zValue;
            u = 0.0f; //uValue;
            t = 0.0f; //tValue;
        }

        /// <summary>
        /// Creates a copy of another Coefficient instance.
        /// </summary>
        /// <param name="other">The Coefficient to copy from</param>
        public Coefficient(Coefficient other)
        {
            s = other.s;
            b = other.b;
            a = other.a;
            m = other.m;
            z = other.z;
            u = other.u;
            t = other.t;
        }
    }

    /// <summary>
    /// A dictionary of coefficients indexed by stat name.
    /// Manages coefficient calculations and applications for all stats simultaneously.
    /// </summary>
    protected class CoefDict
    {
        public Dictionary<string, Coefficient> dict;
        //public statsDictionary stats;

        /// <summary>
        /// Create a new Coefficients Dictionaryfor a given set of Stats
        /// </summary>
        /// <param name="inBaseStats">Should be baseStats to get the starting (pre-MODs) value.</param>
        public CoefDict(statsDictionary inBaseStats) {
            //this.stats = inStats;
            this.dict = inBaseStats.Values.ToDictionary(
                item => item.name,
                item => new Coefficient(item.value)   //Set coefficient sValue from stats's value
            );
        }

        /// <summary>
        /// Add two CoefDict's together.
        /// </summary>
        /// <param name="coef"></param>
        public void Add(CoefDict coef)
        {
            foreach (string name in dict.Keys) {
                dict[name].b += coef.dict[name].b;
                dict[name].a += coef.dict[name].a;
                dict[name].m += coef.dict[name].m;
                dict[name].z += coef.dict[name].z;
                dict[name].u += coef.dict[name].u;
            }
        }

        /// <summary>
        /// Divide all coefficients in a CoefDict by an integer.
        /// [Not sure if this is still relevant]
        /// </summary>
        /// <param name="N">an integer</param>
        public void Div(int N)
        {
            var Nf = (float) N;
            foreach (string name in dict.Keys) {
                dict[name].b /= Nf;
                dict[name].a /= Nf;
                dict[name].m /= Nf;
                dict[name].z /= Nf;
                dict[name].u /= Nf;
            }
        }

        /// <summary>
        /// Apply coefficients to inStats values, to compute effects of MODs.
        /// </summary>
        /// <param name="inStats">Should be baseStats (without any MODs).</param>
        /// <returns></returns>
        public statsDictionary Apply(statsDictionary inStats) 
        {
            statsDictionary outStats = new statsDictionary(inStats); // this shallow copy is ok, because values replaced
            foreach(var name in inStats.Keys) {
                outStats[name].value = Mathf.Min(   Mathf.Max(  (dict[name].s + dict[name].b) * Mathf.Max(0, 1.0f + dict[name].m) + 
                                                                 dict[name].a, inStats[name].min + dict[name].z
                                                             ),
                                                    inStats[name].max + dict[name].u
                                                );
            }   
            return outStats;
        }

        /// <summary>
        /// Get the value of a "SubStat".
        /// Actually just splits prefix and name apart, then calls the other form of GetCoefficient.
        /// </summary>
        /// <param name="prefix_names">A "SubStat" name of the form <prefix>_<statname>.</param>
        /// <returns></returns>
        public float GetCoefficient(string prefix_names) {
            var prefix = char.ToUpper(prefix_names[0]);
            var name = prefix_names.Substring(2).ToUpper(); //remove prefix

            return GetCoefficient(prefix, name);
        }

        /// <summary>
        /// Get coefficient value for a given stat.
        /// </summary>
        /// <param name="prefix">One character prefix identifying the coefficient.</param>
        /// <param name="name">A Stat name</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public float GetCoefficient(char prefix, string name) {
            if (!dict.ContainsKey(name)) {
                throw new Exception($"Bad variable name {name} in {prefix}_{name}");
            }
            switch (prefix) {
                case 'B':
                    return dict[name].b;
                case 'A':
                    return dict[name].a;
                case 'M':
                    return dict[name].m;
                case 'Z':
                    return dict[name].z;
                case 'U':
                    return dict[name].u;
                case 'S':
                    return dict[name].s;
                case 'T':
                    return dict[name].t;
                default:
                    throw new Exception($"Bad variable prefix {prefix} in {prefix}_{name}");
            }
        }

        /// <summary>
        /// Set the value of a stat coefficient given "SubStat" name.
        /// </summary>
        /// <param name="prefix_name">A "SubStat" name of the form <prefix>_<statname>.</param>
        /// <param name="val">A floating point value to assign to the stat coefficient</param>
        /// <exception cref="Exception">Bad Prefix or Bad Stat Name.</exception>
        public void SetCoefficient(string prefix_name, float val) {
            var prefix = char.ToUpper(prefix_name[0]);
            var name = prefix_name.Substring(2).ToUpper(); //ignore x_ prefix
            
            if (!dict.ContainsKey(name)) {
                throw new Exception($"Bad variable name {name} in {prefix}_{name}");
            }
            switch (prefix) {
                case 'B':
                    dict[name].b = val;
                    break;
                case 'A':
                    dict[name].a = val;
                    break;
                case 'M':
                    dict[name].m = val;
                    break;
                case 'Z':
                    dict[name].z = val;
                    break;
                case 'U':
                    dict[name].u = val;
                    break;
                default:
                    if (prefix == 'S' || prefix == 'T')
                        throw new Exception($"S_ and T_ prefixed stats are READ ONLY.");
                    else
                        throw new Exception($"Bad variable prefix {prefix} in {prefix_name}");
            }
            #if MYDEBUG                
                Console.WriteLine($"{prefix}_{name} = {val}");
            #endif
        }
    }
//-------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Default constructor for the Interpreter class.
    /// </summary>
    public Interpreter() {}
    
    /// <summary>
    /// Interprets a list of tokens representing HEL statements and applies their effects to a statistics dictionary.
    /// Parses tokens into statements, analyzes dependencies, orders execution to minimize cycles, and applies modifications.
    /// </summary>
    /// <param name="tokens">The tokenized HEL equations to interpret</param>
    /// <param name="inStats">The base statistics dictionary to modify</param>
    /// <returns>A new statistics dictionary with all mod effects applied</returns>
    /// <exception cref="Exception">Thrown when statements have invalid format or missing mod ID information</exception>
    public static statsDictionary Interpret(List<Token> tokens, statsDictionary inStats) 
    {
        #if MYDEBUG        
            Console.Write("EQUATION:");
            foreach (Token t in tokens) 
                Console.Write($"{t.Value} ");
            Console.WriteLine(" ");
        #endif

        var sumCoefs = new CoefDict(inStats);

        // Parse Tokens into Statements
        List<Statement> statements = SplitStatements(tokens);

        // Order Statements by number of dependency cycles they appear in
        Dictionary<int, List<Statement>> ordered_stmts = Orderer.AnalyzeStatementCycles(statements);
        int max_cycle_count = (ordered_stmts.Keys.Count > 0) ? ordered_stmts.Keys.Max() : 0;

        // Interpret statements with fewer cycles first to reduce missed dependency
        for (int cycle=0; cycle <= max_cycle_count; cycle++) {
            if (ordered_stmts.TryGetValue(cycle, out List<Statement>? stmt_list)) {
                // Within each cycle, order the statements by Index (i.e., by the order they appeared in the input).
                // Initially, equations were ordered by modid. This insured that statement Index follows that ordering.
                // So that within cycles, individual statements are executed in order by modid.
                stmt_list.Sort((a, b) => a.Index.CompareTo(b.Index));

                foreach (var stmt in stmt_list)
                {
                    var stmtCoefs = new CoefDict(inStats);
                    ParseStatement(stmt, stmtCoefs); // Result stored in coefCurr
                    sumCoefs.Add(stmtCoefs);
                }
            }   
        }

        return sumCoefs.Apply(inStats);
    }

    /// <summary>
    /// Splits a list of tokens into individual Statement objects based on semicolons and line endings.
    /// Tracks mod IDs and positions from embedded comment tokens to properly associate statements with their source mods.
    /// </summary>
    /// <param name="tokens">The list of tokens to split into statements</param>
    /// <returns>A list of Statement objects ready for dependency analysis and execution</returns>
    /// <exception cref="Exception">Thrown when mod ID information is missing or invalid</exception>
    private static List<Statement> SplitStatements(List<Token> tokens)
    {
        List<Statement> statements = new List<Statement>();
        List<Token> currentTokens = new List<Token>();
        int modid = -1;
        int modpos = -1;
        int statementIndex = 0;
        foreach (var token in tokens)
        {
            if (token.Type == TokenType.Embed)
            {   // This prevents the comment from proceeding further
                if (token.Value[0] == '#' && token.Value[1] == '!')
                {   //Caller inserts these comments to pass modid and modpos 
                    modid = Token.DecodeComment(token.Value);
                    modpos = 0;
                }
            }
            else if (token.Type == TokenType.Semicolon || token.Type == TokenType.EndOfLine || token.Type == TokenType.EOF)
            {
                if (currentTokens.Count > 0)
                {
                    if (modid < 0 || modpos < 0) {
                        throw new Exception($"ERROR: Equation ModID comment is -1. (SplitStatements)");
                    } else {
                    statements.Add(new Statement(statementIndex, currentTokens, modid, modpos));
                    statementIndex++;
                    modpos++;
                    currentTokens.Clear();
                    }
                }
            }
            else
            {
                currentTokens.Add(token);
            }
        }
        if (currentTokens.Count > 0)
        {
            statements.Add(new Statement(statementIndex, currentTokens, modid, modpos));
        }
        return statements;
    }

    private static Token NextToken(Statement stmt)
    {
        if (stmt.pos == stmt.Tokens.Count)
            return new Token(TokenType.EOF, "EOF", 0);
        else 
            return stmt.Tokens[stmt.pos];
    }


    private static void ParseStatement(Statement stmt, CoefDict coefs)
    {
        /* <statement> ::= <variable> "=" <expression> */
        stmt.pos = 0;
        var lhs = ParseVariable(stmt);
        var next = stmt.Tokens[stmt.pos];

        if (next.Type == TokenType.Assign)
        {
            stmt.pos++;
            var rhsval = ParseExpression(stmt, coefs);
            coefs.SetCoefficient(lhs.Value, rhsval);

            #if MYDEBUG                
                Console.WriteLine($"Interpreter: {lhs.Value} = {rhsval}");
            #endif
        }
        else
        {
            throw new Exception($"Expected '=' but got '{next.Value}' ({next.Type.ToString()})");
        }

    }

    private static Token ParseVariable(Statement stmt)
    {
        var result = stmt.Tokens[stmt.pos]; //Save it to return it

        /* <variable> ::= [bamBAM]_[a-zA-Z]+ */
        if (result.Type == TokenType.LHSVariable)
        {
            stmt.pos++;
        }
        else
        {
            throw new Exception($"Expected LHS variable (e.g., B_, A_, M_) but got '{result.Value}' ({result.Type.ToString()})");
        }

        return result; //return variable token
    }

    private static float ParseExpression(Statement stmt, CoefDict coefs)
    {
        Token? next = stmt.Tokens[stmt.pos];

        /* <expression> ::= <operand> <expression-tail>   */
        stmt.Values.Clear();    //new expression, so clear stack
        if (IsOperand(NextToken(stmt))) 
            ParseOperand(stmt, coefs);         //push first operand on the stack
     
        while (!IsExprEnd(NextToken(stmt)))
            ParseExpressionTail(stmt, coefs);  //evaluate the remainder of the expression

        if (stmt.Values.Count > 1) 
        {
            throw new Exception("Cannot assign multiple values. A function or operator is needed.");
        }
        else if (stmt.Values.Count == 0) 
        {
            throw new Exception("Missing RHS value in equation.");
        }
        else
        {
            float result = stmt.Values.Pop();

            #if MYDEBUG                
                Console.WriteLine($"EXPRESSION = {result}");
            #endif

            return result;
        }
    }

    private static void ParseExpressionTail(Statement stmt, CoefDict coefs)
    {
        /* <expression-tail> ::= <operand> <expression-tail>
                    | <operator> <expression-tail>
                    | <unary-operator> <expression-tail>
                    | <operator>
                    | <unary-operator>
                    | <operand>                                 */

        Token next = NextToken(stmt);
        if (IsOperand(NextToken(stmt))) {
            ParseOperand(stmt, coefs);
            next = NextToken(stmt);
        }
        else if (next.Type == TokenType.Keyword || next.Type == TokenType.Operator)     //function call
        {
            if (stmt.Values.Count > 1) 
            {
                var a = stmt.Values.Pop();
                var b = stmt.Values.Pop();
                switch (next.Value) {
                    case "MAX": { stmt.Values.Push(b > a ? b : a); break; }
                    case "MIN": { stmt.Values.Push(b < a ? b : a); break; }
                    case "+":   { stmt.Values.Push(a + b); break; }
                    case "-":   { stmt.Values.Push(b - a); break; }
                    case "*":   { stmt.Values.Push(a * b); break; }
                    case "/":   { 
                        if (a != 0.0f) 
                            stmt.Values.Push(b / a); 
                        else
                            stmt.Values.Push(float.NaN);    //NaN result
                        break; 
                    }
                    case "^":   { stmt.Values.Push(Mathf.Pow(b, a)); break; }
                    case "AND": { stmt.Values.Push(a * b == 0.0f ? 0.0f : 1.0f); break; }
                    case "OR":  { stmt.Values.Push(a + b == 0.0f ? 0.0f : 1.0f); break; }
                    case "==":  { stmt.Values.Push(Mathf.Equals(a, b) ? 1.0f : 0.0f); break; }
                    case "<>": 
                    case "!=":  { stmt.Values.Push(Mathf.Equals(a, b) ? 0.0f : 1.0f); break; }   
                    case "<":   { stmt.Values.Push(b < a ? 0.0f : 1.0f); break; }                //"1 4 <" is TRUE
                    case "<=":  { stmt.Values.Push(b <= a ? 0.0f : 1.0f); break; }               //"1 4 <=" is TRUE
                    case ">":   { stmt.Values.Push(b > a ? 0.0f : 1.0f); break; }                //"1 4 >" is FALSE
                    case ">=":  { stmt.Values.Push(b >= a ? 0.0f : 1.0f); break; }               //"1 4 >=" is FALSE
                    // Add new binary functions here
                    default:    { stmt.Values.Push(float.NaN); break; }
                }
            }
            else if (stmt.Values.Count == 1)
            {
                var a = stmt.Values.Pop();
                switch (next.Value) {
                    case "CEIL":    { stmt.Values.Push(Mathf.Ceiling(a)); break; }
                    case "FLOOR":   { stmt.Values.Push(Mathf.Floor(a)); break; }
                    case "NOT":     { stmt.Values.Push(a == 0.0f ? 1.0f : 0.0f); break; }
                    // Add new unary functions here
                    default:        { stmt.Values.Push(float.NaN); break; }
                }
            }
            else 
            {
                switch (next.Value) {
                    case "RAND":    
                    { 
                        Random random = new Random();
                        stmt.Values.Push( (float)random.NextDouble() );
                        break;
                    }
                    case "TRUE":    { stmt.Values.Push(1.0f); break; }
                    case "FALSE":   { stmt.Values.Push(0.0f); break; }
                    // Add new symbolic values here
                    default:        { stmt.Values.Push(float.NaN); break; }
                }
            }

            #if MYDEBUG                
                Console.WriteLine($"{next.Value} --> {stmt.Values.Peek()}");
            #endif

            stmt.pos++;  //consume the function name
        }
        else if (!IsExprEnd(next)) 
        {
            throw new Exception($"Unexpected symbol '{next.Value}'.");
        }
    }

    /// <summary>
    /// Parse numbers and RHS variables
    /// </summary>
    /// <returns>The corresponding Token</returns>
    /// <exception cref="Exception"></exception>
    private static void ParseOperand(Statement stmt, CoefDict coefs)
    {
        var next = stmt.Tokens[stmt.pos];

        /* <operand> ::= ["-"] [0-9]+
                        | ["-"] [0-9]+ "." [0-9]+
                        | ["-"] [szubamSZUBAM]_[a-zA-Z]+     */

        if (next.Type == TokenType.Number) 
            stmt.Values.Push(next.NumVal);
        else //Must be a RHS variable. Lookup coefficient
            stmt.Values.Push(coefs.GetCoefficient(next.Value));

        #if MYDEBUG            
            Console.WriteLine($"OPERAND: {stmt.Values.Peek()}");
        #endif

        stmt.pos++;
    }


    /// <summary>
    /// Is 'token' a number, variable or RAND?
    /// </summary>
    /// <param name="token"></param>
    /// <returns>Boolean</returns>
    private static bool IsOperand(Token token)
    {
        return token.Type == TokenType.Number || token.Type == TokenType.RHSVariable || token.Type == TokenType.LHSVariable;
    }
    
    private static bool IsExprEnd(Token? token)
    {
        return (token is null || token.Type == TokenType.EndOfLine || token.Type == TokenType.Semicolon || token.Type == TokenType.EOF);
    }

}
