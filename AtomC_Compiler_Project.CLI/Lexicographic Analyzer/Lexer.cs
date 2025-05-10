namespace AtomC_Compiler_Project.CLI.Lexicographic_Analyzer;
using System;
using System.Collections.Generic;
using System.IO; 

public class Lexer(string sourceCode)
{
    private readonly Handler _handler = new();
    private int _currentIndex = 0;

    public void GetNextToken()
    { 
        int state = 0;
        char currentChar;
        string tokenValue =  string.Empty;
        while (true)
        {
            if (_currentIndex >= sourceCode.Length) {
                currentChar = '\0';
            } else {
                currentChar = sourceCode[_currentIndex];
            }
            
            switch (state)
            {
                case 0:
                    if (Char.IsLetter(currentChar) || currentChar == '_')
                    {
                        tokenValue += currentChar;
                        _currentIndex++;
                        state = 1;
                    }
                    else if (currentChar == '=')
                    {
                        tokenValue += currentChar;
                        _currentIndex++;
                        state = 3;
                    }
                    else if (currentChar == ' ' || currentChar == '\t' || currentChar == '\r')
                    {
                        _currentIndex++;
                    }
                    else if (currentChar == '\n')
                    {
                        _handler.IncrementLine();
                        _currentIndex++;
                        
                    }
                    else if (currentChar == '\0'){
                        
                        _handler.AddToken(TokenCode.End, "\\0");
                        return;
                    }
                    else
                    {   
                        
                        _handler.TokenError(_handler.AddToken(TokenCode.Invalid, currentChar.ToString()), $"Invalid character: '{currentChar}'");
                    }
                    break;
                case 1:
                    if (Char.IsLetter(currentChar) || Char.IsNumber(currentChar) || currentChar == '_')
                    {
                        tokenValue += currentChar;
                        _currentIndex++;
                    }
                    else state = 2;
                    break;
                case 2:
                    int tokenValueLength =tokenValue.Length;
                    if (tokenValueLength == 5 && tokenValue == "break")
                    {
                        _handler.AddToken(TokenCode.Break, tokenValue);
                    }
                    else if (tokenValueLength == 4 && tokenValue == "char")
                    {
                        _handler.AddToken(TokenCode.Char, tokenValue);
                    }
                    else if (tokenValueLength == 5 && tokenValue == "false")
                    {
                        _handler.AddToken(TokenCode.False, tokenValue);
                    }
                    else if (tokenValueLength == 5 && tokenValue == "while")
                    {
                        _handler.AddToken(TokenCode.While, tokenValue);
                    }
                    else if (tokenValueLength == 5 && tokenValue == "if")
                    {
                        _handler.AddToken(TokenCode.If, tokenValue);
                    }
                    else if (tokenValueLength == 6 && tokenValue == "return")
                    {
                        _handler.AddToken(TokenCode.Return, tokenValue);
                    }
                    else if (tokenValueLength == 6 && tokenValue == "for")
                    {
                        _handler.AddToken(TokenCode.For, tokenValue);
                    }
                    else if (tokenValueLength == 4 && tokenValue == "else")
                    {
                        _handler.AddToken(TokenCode.Else, tokenValue);
                    }
                    else if (tokenValueLength == 7 && tokenValue == "double")
                    {
                        _handler.AddToken(TokenCode.Double, tokenValue);
                    }
                    else if (tokenValueLength == 7 && tokenValue == "integer")
                    {
                        _handler.AddToken(TokenCode.Integer, tokenValue);
                    }
                    else if (tokenValueLength == 4 && tokenValue == "void")
                    {
                        _handler.AddToken(TokenCode.Void, tokenValue);
                    }
                    else if (tokenValueLength == 4 && tokenValue == "true")
                    {
                        _handler.AddToken(TokenCode.True, tokenValue);
                    }
                    else
                    {
                        _handler.AddToken(TokenCode.Id, tokenValue);
                    }
                    return;
                case 3:
                    if (currentChar == '=')
                    {
                        tokenValue += currentChar;
                        _currentIndex++;
                        state = 4;
                    }
                    else state = 5;
                    break;
                case 4:
                    _handler.AddToken(TokenCode.Equal, tokenValue);
                    return;
                case 5:
                    _handler.AddToken(TokenCode.Assign, tokenValue);
                    return;
                    
            }
        }
        
        
    }
    
    public void PrintAllTokens()
    {
        Console.WriteLine("=== Token List ===");
        foreach (var token in _handler.TokenList)
        {
            Console.WriteLine($"Line {token.Line}: {token.Code} -> {token.Value}");
        }
        Console.WriteLine("==================");
    }
}
