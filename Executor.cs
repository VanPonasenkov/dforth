using System.Collections.Generic;
using System.Linq;
public class Executor 
{
    public List<int> stack {get;set;}
    private Dictionary<string, List<Token>> lookup;
    public Executor()
    {
        this.stack = new();
        this.lookup = new();
    }
    public void Execute(List<Token> tokens)
    {
        bool isCmpTime = false;
        bool isIdentFound = false;
        string curr_ident = "";
        
        foreach(Token token in tokens)
        {
            if(isCmpTime)
            {
                if(!isIdentFound)
                {
                    curr_ident = (string)token.value;
                    isIdentFound = true;
                    this.lookup.Add(curr_ident, new());
                    continue;
                }
                else
                {
                    if(token.tokenType != TokenEnum.CMPEN)
                    {
                        this.lookup[curr_ident].Add(token);
                        continue;
                    }
                    else
                    {
                        isCmpTime = false;
                        isIdentFound = false;
                        curr_ident = "";
                    }
                }
            }
            
            switch(token.tokenType)
            {
                
                case TokenEnum.NUM: 
                {
                    if(this.lookup.ContainsKey(token.value))
                    {
                        this.Execute(this.lookup[token.value]);
                        break;
                    }
                    try
                    {
                        stack.Add((int)int.Parse(token.value));
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("token: " + token.value);
                    }
                    break;
                }
                case TokenEnum.DIV:
                {
                    int a = stack.Aggregate((a,c) => a/c);
                    stack.Clear();
                    stack.Add(a);
                    break;
                }
                case TokenEnum.PLUS:
                {
                    int a = stack.Aggregate((a,c) => a+c);
                    stack.Clear();
                    stack.Add(a);
                    break;
                }
                case TokenEnum.MINUS:
                {
                    int a = stack.Aggregate((a,c) => a-c);
                    stack.Clear();
                    stack.Add(a);
                    break;
                }
                case TokenEnum.MUL:
                {
                    int a = stack.Aggregate((a,c) => a*c);
                    stack.Clear();
                    stack.Add(a);
                    break;
                }
                case TokenEnum.DOT:
                {
                    Console.Write(stack[stack.Count - 1]);
                    stack.RemoveAt(stack.Count - 1);
                    break;
                }
                case TokenEnum.CMPST:
                {
                    isCmpTime = true;
                    break;
                }
                case TokenEnum.DUP:
                {
                    stack.Add(stack[stack.Count - 1]);
                    break;
                }
            }
        }
    }
}