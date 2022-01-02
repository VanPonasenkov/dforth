
public class Show : IIntrinsic
{
    public Show()
    {
        this.Repr = ".S";
    }

    public string Repr { get;set; }
    public void use(List<int> stack)
    {
        foreach(var val in stack)
        {
            Console.Write(val + " ");
        }
    }
}