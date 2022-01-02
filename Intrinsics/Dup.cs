
public class Dup : IIntrinsic
{
    public Dup()
    {
        this.Repr = "DUP";
    }

    public string Repr { get;set; }
    public void use(List<int> stack)
    {
        stack.Add(stack[stack.Count - 1]);
    }
}