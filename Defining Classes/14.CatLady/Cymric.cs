public class Cymric : Cat
{
    protected double furLen;
    public Cymric(string name, string breed, double furLen) : base(name, breed)
    {
        this.furLen = furLen;
    }

    public override string ToString()
    {
        return $"{base.ToString()} {this.furLen:f2}";
    }
}
