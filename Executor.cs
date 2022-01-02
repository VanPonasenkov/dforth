using System.Collections.Generic;
using System.Linq;
public class Executor 
{
    public List<int> stack {get;set;}
    private Dictionary<string, List<Token>> lookup;
    private IIntrinsic[] intrinsics;
    
    private (bool has, IIntrinsic? In) hasArrRepr(IIntrinsic[] arr, string str_val)
    {
        foreach(IIntrinsic In in arr)
        {
            if(In.Repr == str_val)
            {
                return (has: true, In: In);
            }
        }
        return (has: false, In: null);
    }
    public Executor()
    {
        this.stack = new();
        this.lookup = new();
        this.intrinsics = new IIntrinsic[]
        {
            new Dup(),
            new Swap(),
            new Show()
        };
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
                    (bool has, IIntrinsic In) hARPR =hasArrRepr(this.intrinsics, token.value);
                    if(this.lookup.ContainsKey(token.value))
                    {
                        this.Execute(this.lookup[token.value]);
                        break;
                    }
                    else if(hARPR.has)
                    {
                        hARPR.In.use(this.stack);
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
                    int len = stack.Count;
                    int n1 = stack[len - 2];
                    int n2 = stack[len - 1];
                    int a = n1 / n2;
                    stack.RemoveAt(len - 1);
                    stack.RemoveAt(len - 2);
                    stack.Add(a);
                    break;
                }
                case TokenEnum.PLUS:
                {
                    int len = stack.Count;
                    int n1 = stack[len - 2];
                    int n2 = stack[len - 1];
                    int a = n1 + n2;
                    stack.RemoveAt(len - 1);
                    stack.RemoveAt(len - 2);
                    stack.Add(a);
                    break;
                }
                case TokenEnum.MINUS:
                {
                    int len = stack.Count;
                    int n1 = stack[len - 2];
                    int n2 = stack[len - 1];
                    int a = n1 - n2;
                    stack.RemoveAt(len - 1);
                    stack.RemoveAt(len - 2);
                    stack.Add(a);
                    break;
                }
                case TokenEnum.MUL:
                {
                    int len = stack.Count;
                    int n1 = stack[len - 2];
                    int n2 = stack[len - 1];
                    int a = n1 * n2;
                    stack.RemoveAt(len - 1);
                    stack.RemoveAt(len - 2);
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
            }
        }
    }
}