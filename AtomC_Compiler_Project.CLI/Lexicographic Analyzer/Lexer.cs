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
            { // initial state
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
                    else if (currentChar == '+')
                    {
                        tokenValue += currentChar;
                        _currentIndex++;
                        state = 4;
                    }
                    else if (currentChar == '-')
                    {
                        tokenValue += currentChar;
                        _currentIndex++;
                        state = 5;
                    }
                    else if (currentChar == '*')
                    {
                        tokenValue += currentChar;
                        _currentIndex++;
                        state = 6;
                    }
                    else if (currentChar == '/')
                    {
                        state = 7;
                    }
                    else if (currentChar == '.')
                    {
                        tokenValue += currentChar;
                        _currentIndex++;
                        state = 8;
                    }
                    else if (currentChar == '&')
                    {
                        tokenValue += currentChar;
                        _currentIndex++;
                        state = 9;
                    }
                    else if (currentChar == '|')
                    {
                        tokenValue += currentChar;
                        _currentIndex++;
                        state = 10;
                    }
                    else if (currentChar == '!')
                    {
                        tokenValue += currentChar;
                        _currentIndex++;
                        state = 11;
                    }
                    else if (currentChar == '<')
                    {
                        tokenValue += currentChar;
                        _currentIndex++;
                        state = 12;
                    }
                    else if (currentChar == '>')
                    {
                        tokenValue += currentChar;
                        _currentIndex++;
                        state = 13;
                    }
                    else if (currentChar == '[')
                    {
                        tokenValue += currentChar;
                        _currentIndex++;
                        state = 18;
                    }
                    else if (currentChar == ']')
                    {
                        tokenValue += currentChar;
                        _currentIndex++;
                        state = 19;
                    }
                    else if (currentChar == '{')
                    {
                        tokenValue += currentChar;
                        _currentIndex++;
                        state = 20;
                    }
                    else if (currentChar == '}')
                    {
                        tokenValue += currentChar;
                        _currentIndex++;
                        state = 21;
                    }
                    else if (currentChar == ',')
                    {
                        tokenValue += currentChar;
                        _currentIndex++;
                        state = 22;
                    }
                    else if (currentChar == ';')
                    {
                        tokenValue += currentChar;
                        _currentIndex++;
                        state = 23;
                    }
                    else if (currentChar == '(')
                    {
                        tokenValue += currentChar;
                        _currentIndex++;
                        state = 24;
                    }
                    else if (currentChar == ')')
                    {
                        tokenValue += currentChar;
                        _currentIndex++;
                        state = 25;
                    }
                    else if (Char.IsDigit(currentChar))
                    {
                        tokenValue += currentChar;
                        _currentIndex++;
                        state = 29;
                    }
                    else if (currentChar == '\'')
                    {
                        tokenValue += currentChar;
                        _currentIndex++;
                        state = 34; 
                    }
                    else if (currentChar == '"')
                    {
                        tokenValue += currentChar;
                        _currentIndex++;
                        state = 37;
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
                        
                        _handler.TokenError(_handler.AddToken(TokenCode.Invalid, currentChar.ToString()), $"Invalid token: '{tokenValue}'");
                    }
                    break;
                //State 1 Char or Underscore
                case 1:
                    if (Char.IsLetter(currentChar) || Char.IsNumber(currentChar) || currentChar == '_')
                    {
                        tokenValue += currentChar;
                        _currentIndex++;
                    }
                    else state = 2;
                    break;
                // state 2 keywords
                case 2:
                    int tokenValueLength =tokenValue.Length;
                    if (tokenValueLength == 5 && tokenValue == "break")
                    {
                        _handler.AddToken(TokenCode.Break, tokenValue);
                    }
                    if (tokenValueLength == 6 && tokenValue == "struct")
                    {
                        _handler.AddToken(TokenCode.Struct, tokenValue);
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
                    else if (tokenValueLength == 2&& tokenValue == "if")
                    {
                        _handler.AddToken(TokenCode.If, tokenValue);
                    }
                    else if (tokenValueLength == 6 && tokenValue == "return")
                    {
                        _handler.AddToken(TokenCode.Return, tokenValue);
                    }
                    else if (tokenValueLength == 3 && tokenValue == "for")
                    {
                        _handler.AddToken(TokenCode.For, tokenValue);
                    }
                    else if (tokenValueLength == 4 && tokenValue == "else")
                    {
                        _handler.AddToken(TokenCode.Else, tokenValue);
                    }
                    else if (tokenValueLength == 6 && tokenValue == "double")
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
                // State 3 - 17 operators
                case 3:
                    if (currentChar == '=')
                    {
                        tokenValue += currentChar;
                        _currentIndex++;
                        state = 14;
                    }
                    else
                    {
                        _handler.AddToken(TokenCode.Assign, tokenValue);
                        return;
                    }
                    break;
                case 4:
                    _handler.AddToken(TokenCode.Add, tokenValue);
                    return;
                case 5:
                    _handler.AddToken(TokenCode.Sub, tokenValue);
                    return;
                case 6:
                    _handler.AddToken(TokenCode.Mul, tokenValue);
                    return;
                case 7:
                    if (sourceCode[_currentIndex+1]=='/')
                    {
                        _currentIndex += 2; 
                        
                        state = 26; 
                    }
                    else if (sourceCode[_currentIndex+1] == '*')
                    {
                        _currentIndex += 2; 
                        state = 28; 
                    }
                    else
                    {
                        tokenValue += currentChar;
                        _currentIndex++;
                        _handler.AddToken(TokenCode.Div, tokenValue);
                        return;
                    }
                    break;
                case 8:
                    _handler.AddToken(TokenCode.Dot, tokenValue);
                    return;
                case 9:
                    if (currentChar == '&')
                    {
                        tokenValue += currentChar;
                        _currentIndex++;
                        _handler.AddToken(TokenCode.And, tokenValue);
                    }
                    else
                    {
                        tokenValue += currentChar;
                        _handler.TokenError(_handler.AddToken(TokenCode.Invalid, currentChar.ToString()), $"Invalid operator: '{tokenValue}'");
                        
                    }
                    return;
                case 10:
                    if (currentChar == '|')
                    {
                        tokenValue += currentChar;
                        _currentIndex++;
                        _handler.AddToken(TokenCode.Or, tokenValue);
                    }
                    else
                    {
                        tokenValue += currentChar;
                        _handler.TokenError(_handler.AddToken(TokenCode.Invalid, currentChar.ToString()), $"Invalid operator: '{tokenValue}'");
                        
                    }
                    return;
                case 11:
                    if (currentChar == '=')
                    {
                        tokenValue += currentChar;
                        _currentIndex++;
                        state = 15;
                    }else
                        _handler.AddToken(TokenCode.Not, tokenValue);
                    break;
                case 12:
                    if (currentChar == '=')
                    {
                        tokenValue += currentChar;
                        _currentIndex++;
                        state = 16;
                    }else
                    {
                        _handler.AddToken(TokenCode.Less, tokenValue);
                        return;
                    }
                    break;
                case 13:
                    if (currentChar == '=')
                    {
                        tokenValue += currentChar;
                        _currentIndex++;
                        state = 17;
                    }
                    else
                    {
                        _handler.AddToken(TokenCode.Greater, tokenValue);
                        return;
                    }
                    break;
                case 14:
                    _handler.AddToken(TokenCode.Equal, tokenValue);
                    return;
                case 15:
                    _handler.AddToken(TokenCode.Noteq,  tokenValue);
                    return;
                case 16:
                    _handler.AddToken(TokenCode.Lesseq,  tokenValue);
                    return;
                case 17:
                    _handler.AddToken(TokenCode.Greatereq,  tokenValue);
                    return;
                // State 18 - 25 separators 
                case 18:
                    _handler.AddToken(TokenCode.LBracket, tokenValue);
                    return;

                case 19:
                    _handler.AddToken(TokenCode.RBracket, tokenValue);
                    return;

                case 20:
                    _handler.AddToken(TokenCode.LAcc, tokenValue);
                    return;

                case 21:
                    _handler.AddToken(TokenCode.RAcc, tokenValue);
                    return;
                case 22:
                    _handler.AddToken(TokenCode.Comma, tokenValue);
                    return;

                case 23:
                    _handler.AddToken(TokenCode.Semicolon, tokenValue);
                    return;

                case 24:
                    _handler.AddToken(TokenCode.LPar, tokenValue);
                    return;
                
                case 25:
                    _handler.AddToken(TokenCode.RPar, tokenValue);
                    return;
                //State 26 - 28 comments
                
                case 26: // Inside line comment
                    if (currentChar == '\n')
                    {
                        _handler.IncrementLine();
                        _currentIndex++;
                        state = 0; 
                    }
                    else if (currentChar == '\0')
                    {
                        return; 
                    }
                    else
                    {
                        _currentIndex++; 
                    }
                    break;

                case 27: 
                    if (currentChar == '*')
                    {
                        _currentIndex++;
                        state = 28; 
                    }
                    else
                    {
                        if (currentChar == '\n') _handler.IncrementLine();
                        if (currentChar == '\0')
                        {
                            _handler.Error("Unterminated block comment");
                            return;
                        }
                        _currentIndex++;
                    }
                    break;

                case 28: // Maybe end of block comment
                    if (currentChar == '/')
                    {
                        _currentIndex++;
                        state = 0; 
                    }
                    else if (currentChar == '*')
                    {
                        _currentIndex++; 
                    }
                    else
                    {
                        if (currentChar == '\n') _handler.IncrementLine();
                        if (currentChar == '\0')
                        {
                            _handler.Error("Unterminated block comment");
                            return;
                        }
                        _currentIndex++;
                        state = 27;
                    }
                    break;
            //29 - 38 constants
                case 29: //numbers
                    if (Char.IsDigit(currentChar))
                    {
                        tokenValue += currentChar;
                        _currentIndex++;
                    }
                    else if (currentChar == '.')
                    {
                        tokenValue += currentChar;
                        _currentIndex++;
                        state = 30; 
                    }
                    else if (currentChar == 'e' || currentChar == 'E')
                    {
                        tokenValue += currentChar;
                        _currentIndex++;
                        state = 31; 
                    }
                    else
                    {
                        _handler.AddToken(TokenCode.CtInt, tokenValue);
                        return;
                    }
                    break;

                case 30: // After decimal point
                    if (Char.IsDigit(currentChar))
                    {
                        tokenValue += currentChar;
                        _currentIndex++;
                    }
                    else if (currentChar == 'e' || currentChar == 'E')
                    {
                        tokenValue += currentChar;
                        _currentIndex++;
                        state = 31;
                    }
                    else
                    {
                        _handler.AddToken(TokenCode.CtReal, tokenValue);
                        return;
                    }
                    break;

                case 31: // After 'e' or 'E'
                    if (currentChar == '+' || currentChar == '-')
                    {
                        tokenValue += currentChar;
                        _currentIndex++;
                        state = 32;
                    }
                    else if (Char.IsDigit(currentChar))
                    {
                        tokenValue += currentChar;
                        _currentIndex++;
                        state = 33;
                    }
                    else
                    {
                        _handler.TokenError(_handler.AddToken(TokenCode.Invalid, tokenValue), "Invalid exponent format");
                        return;
                    }
                    break;

                case 32: // After exponent sign
                    if (Char.IsDigit(currentChar))
                    {
                        tokenValue += currentChar;
                        _currentIndex++;
                        state = 33;
                    }
                    else
                    {
                        _handler.TokenError(_handler.AddToken(TokenCode.Invalid, tokenValue), "Invalid exponent format");
                        return;
                    }
                    break;

                case 33: // Digits after exponent
                    if (Char.IsDigit(currentChar))
                    {
                        tokenValue += currentChar;
                        _currentIndex++;
                    }
                    else
                    {
                        _handler.AddToken(TokenCode.CtReal, tokenValue);
                        return;
                    }
                    break;
                case 34: // After opening single quote
                    if (currentChar == '\\')
                    {
                        tokenValue += currentChar;
                        _currentIndex++;
                        state = 35;
                    }
                    else
                    {
                        tokenValue += currentChar;
                        _currentIndex++;
                        state = 36;
                    }
                    break;

                case 35: // Escape character in char
                    if ("abfnrtv'\"\\0".Contains(currentChar))
                    {
                        tokenValue += currentChar;
                        _currentIndex++;
                        state = 36;
                    }
                    else
                    {
                        _handler.TokenError(_handler.AddToken(TokenCode.Invalid, tokenValue), "Invalid escape sequence in char");
                        return;
                    }
                    break;

                case 36: //  closing quote
                    if (currentChar == '\'')
                    {
                        tokenValue += currentChar;
                        _currentIndex++;
                        _handler.AddToken(TokenCode.CtChar, tokenValue);
                        return;
                    }
                    else
                    {
                        _handler.TokenError(_handler.AddToken(TokenCode.Invalid, tokenValue), "Unterminated char literal");
                        return;
                    }
                case 37: // I string
                    if (currentChar == '\\')
                    {
                        tokenValue += currentChar;
                        _currentIndex++;
                        state = 38;
                    }
                    else if (currentChar == '"')
                    {
                        tokenValue += currentChar;
                        _currentIndex++;
                        _handler.AddToken(TokenCode.CtString, tokenValue);
                        return;
                    }
                    else if (currentChar == '\0')
                    {
                        _handler.TokenError(_handler.AddToken(TokenCode.Invalid, tokenValue), "Unterminated string literal");
                        return;
                    }
                    else
                    {
                        if (currentChar == '\n') _handler.IncrementLine();
                        tokenValue += currentChar;
                        _currentIndex++;
                    }
                    break;

                case 38: // Escape in string
                    if ("abfnrtv'\"\\0".Contains(currentChar))
                    {
                        tokenValue += currentChar;
                        _currentIndex++;
                        state = 50;
                    }
                    else
                    {
                        _handler.TokenError(_handler.AddToken(TokenCode.Invalid, tokenValue), "Invalid escape sequence in string");
                        return;
                    }
                    break;  
            }
        }
        
        
    }
    public void TokenizeAll()
    {
        while (true)
        {
            GetNextToken();

            if (_handler.TokenList.Count > 0 &&
                _handler.TokenList[^1].Code == TokenCode.End)
            {
                break;
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
