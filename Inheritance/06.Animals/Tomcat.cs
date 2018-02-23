public class Tomcat : Cat
{
    private const string GenderType = "Male";

    public Tomcat(string name, string age, string gender) 
        : base(name, age, gender)
    {
        this.Gender = GenderType;
    }

    public override string ProduceSound()
    {
        return "MEOW";
    }
}
