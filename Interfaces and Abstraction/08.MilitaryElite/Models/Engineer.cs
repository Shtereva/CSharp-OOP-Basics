using System;
using System.Collections.Generic;
using System.Linq;

public class Engineer : SpecialisedSoldier, IEngineer
{
    public CorpsType Corps { get; set; }

    public List<IRepair> Repairs { get; set; }

    public Engineer(string id, string firstName, string lastName, double salary, CorpsType corps, List<IRepair> repairs) 
        : base(id, firstName, lastName, salary, corps)
    {
        this.Repairs = repairs;
    }
    public override string ToString()
    {
        string nl = Environment.NewLine;
        string repairs = this.Repairs.Any() ? $"{nl} {string.Join($"{nl} ", this.Repairs)}" : String.Empty;
        return $"{base.ToString()}{nl}Repairs:{repairs}";
    }
   
}
