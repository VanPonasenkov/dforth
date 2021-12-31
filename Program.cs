using System;
using System.Linq;
using System.Collections.Generic;
public class Program
{
    public static void Main(string[] args)
    {
        string text = "";
        foreach (var str in File.ReadAllLines(args[0]))
        {
            text += str + " ";
        }
        text = text.Trim();
        Executor executor = new();
        executor.Execute(Tokenizer.Tokenize(text));
    }
}