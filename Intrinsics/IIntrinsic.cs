using System.Collections.Generic;
public interface IIntrinsic 
{
    string Repr {get;set;}
    
    void use(List<int> stack);
}