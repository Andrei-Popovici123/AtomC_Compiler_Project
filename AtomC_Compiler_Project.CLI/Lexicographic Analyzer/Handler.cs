namespace AtomC_Compiler_Project.CLI.Lexicographic_Analyzer;


public enum TokenCode
{
    Id,
    End,
    Break,
    Invalid,
    Char,
    Double,
    Integer,
    Else,
    If,
    Return,
    True,
    False,
    For,
    While,
    Void,
    Equal,
    Assign,
    
}
public class Token
{
    public TokenCode Code { get; set; }
    public string Value { get; set; }
    public int Line { get; set; }

    public Token(TokenCode code, string value, int line)
    {
        Code = code;
        Value = value;
        Line = line;
    }
}
public class Handler
{
    
    public List<Token> TokenList { get;  }= new List<Token>();
    private int Line { get; set; } = 1;

    public Token AddToken(TokenCode code, string value)
    {   Token token = new Token(code, value, Line);
        TokenList.Add(token);
        return token;
    }

    public int IncrementLine()
    {
        Line++;
        return Line;
    }

    public void Error(string message)
    {
        Console.Error.WriteLine($"Error: {message}");
        Environment.Exit(-1);
    }

    public void TokenError(Token token, string message)
    {
        Console.Error.WriteLine($"Error at line {token.Line}: {message}");
        Environment.Exit(-1);
    }
}