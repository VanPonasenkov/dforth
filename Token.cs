public class Token
{
    public Token(TokenEnum tokenType, dynamic value)
    {
        this.tokenType = tokenType;
        this.value = value;
    }


    public TokenEnum tokenType { get; set; }
    public dynamic value { get; set; }


    public override string? ToString()
    {
        return $"{value}";
    }
}