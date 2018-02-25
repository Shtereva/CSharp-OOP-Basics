using System;

public abstract class SpecialisedSoldier : PrivateGeneral, ISpecialisedSoldier
{
    public CorpsType Corps { get; set; }

    public SpecialisedSoldier(string id, string firstName, string lastName, double salary, CorpsType corps) 
        : base(id, firstName, lastName, salary)
    {
        this.Corps = corps;
    }

    public override string ToString()
    {
        return $"{base.ToString()}{Environment.NewLine}Corps: {this.Corps}";
    }
}
