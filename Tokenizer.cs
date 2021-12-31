using System.Collections.Generic;
public class Tokenizer
{
    public static List<Token> Tokenize(string line)
    {
        string[] splits = line.Split(" ");
        List<Token> tokens = new();

        foreach (string s in splits)
        {
            switch (s)
            {
                case "+": tokens.Add(new Token(TokenEnum.PLUS, "+")); break;
                case "-": tokens.Add(new Token(TokenEnum.MINUS, "-")); break;
                case "/": tokens.Add(new Token(TokenEnum.DIV, "/")); break;
                case "*": tokens.Add(new Token(TokenEnum.MUL, "*")); break;
                case "!": tokens.Add(new Token(TokenEnum.FAC, "!")); break;
                case ".": tokens.Add(new Token(TokenEnum.DOT, ".")); break;
                case ":": tokens.Add(new Token(TokenEnum.CMPST, ":")); break;
                case ";": tokens.Add(new Token(TokenEnum.CMPEN, ";")); break;
                case "DUP": tokens.Add(new Token(TokenEnum.DUP, "DUP")); break;
                default: tokens.Add(new Token(TokenEnum.NUM, s)); break;
            }
        }
        return tokens;
    }
}