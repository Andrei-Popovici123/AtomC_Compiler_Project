namespace AtomC_Compiler_Project.Core.Lexicographic_Analyzer;


public enum TokenCode
{
    Id,
    End,
    Break,
    
}
public class Token
{
    public TokenCode Code { get; set; }
    public object Value { get; set; }
    public int Line { get; set; }

    public Token(TokenCode code, object value, int line)
    {
        Code = code;
        Value = value;
        Line = line;
    }
}
public class Handler
{
    
    public List<Token> TokenList { get;  }= new List<Token>();
    public int Line { get; set; } = 1;

    public Token AddToken(TokenCode code, object value)
    {   Token token = new Token(code, value, Line);
        TokenList.Add(token);
        return token;
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