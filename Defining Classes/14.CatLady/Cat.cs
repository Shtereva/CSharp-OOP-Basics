public class Cat  
{
    protected string name;
    protected string breed;
    public Cat(string name, string breed)
    {
        this.name = name;
        this.breed = breed;
    }

    public string Name => this.name;
    public override string ToString()
    {
        return $"{this.breed} {this.name}";
    }
}
