public class StreetExtraordinaire : Cat
{
    private int decibels;
    public StreetExtraordinaire(string name, string breed, int decibels) : base(name, breed)
    {
        this.decibels = decibels;
    }

    public override string ToString()
    {
        return $"{base.ToString()} {this.decibels}";
    }
}
