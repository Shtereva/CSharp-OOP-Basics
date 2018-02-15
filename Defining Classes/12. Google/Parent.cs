using System;
public class Parent
{
    private string name;
    private string birthday;

    public string Name => this.name;
    public string BirthDay => this.birthday;

    public Parent(string name, string birthday)
    {
        this.name = name;
        this.birthday = birthday;
    }

    public override string ToString()
    {
        string nl = Environment.NewLine;

        return $"{this.name} {this.birthday}";
    }
}
