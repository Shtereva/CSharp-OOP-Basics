    public class Siamese : Cat
    {
        protected int earSize;
    public Siamese(string name, string breed, int earSize) : base(name, breed)
    {
        this.earSize = earSize;
    }

    public override string ToString()
    {
        return $"{base.ToString()} {this.earSize}";
    }
}
