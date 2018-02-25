using System;
using System.Collections.Generic;
using System.Linq;

public class Commando : SpecialisedSoldier, ICommando
{
    public CorpsType Corps { get; set; }
    public List<IMission> Missions { get; set; }
    public Commando(string id, string firstName, string lastName, double salary, CorpsType corps, List<IMission> missions) 
        : base(id, firstName, lastName, salary, corps)
    {
        this.Missions = missions;
    }
    public override string ToString()
    {
        string nl = Environment.NewLine;
        string missions = this.Missions.Any() ? $"{nl} {string.Join($"{nl} ", this.Missions)}" : String.Empty;
        return $"{base.ToString()}{nl}Missions:{missions}";
    }
}
