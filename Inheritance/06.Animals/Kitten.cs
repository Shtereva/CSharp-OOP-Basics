public class Kitten : Cat
{
    private const string GenderType = "Female";

    public Kitten(string name, string age, string gender) 
        : base(name, age, gender)
    {
        this.Gender = GenderType;
    }

    public override string ProduceSound()
    {
        return "Meow";
    }
}
