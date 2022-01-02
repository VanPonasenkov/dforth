
public class Swap : IIntrinsic
{
    public Swap()
    {
        this.Repr = "SWAP";
    }

    public string Repr { get;set; }
    public void use(List<int> stack)
    {
        int len = stack.Count;
        int n1 = stack[len - 2];
        int n2 = stack[len - 1];
        stack.RemoveAt(len - 2);
        stack.Add(n1);
    }
}