using System;

public class Spy : SoldierGeneral, ISpy
{
    public int CodeNumber { get; set; }
    public Spy(string id, string firstName, string lastName, int codeNumber)
        : base(id, firstName, lastName)
    {
        this.CodeNumber = codeNumber;
    }

    public override string ToString()
    {
        return $"{base.ToString()}{Environment.NewLine}Code Number: {this.CodeNumber}";
    }
}
