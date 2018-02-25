using System;
using System.Collections.Generic;
using System.Linq;

public class LeutenantGeneral : PrivateGeneral, ILeutenantGeneral
{
    public List<PrivateGeneral> Privates { get; set; }
    

    public LeutenantGeneral(string id, string firstName, string lastName, double salary)
        : base(id, firstName, lastName, salary)
    {
        this.Privates = new List<PrivateGeneral>();
    }

    public void AddPrivate(PrivateGeneral @private)
    {
        this.Privates.Add(@private);
    }
    public override string ToString()
    {
        string nl = Environment.NewLine;
        string privates = this.Privates.Any() ? $"{nl} {string.Join($"{nl} ", this.Privates)}" : String.Empty;
        return $"{base.ToString()}{nl}Privates:{privates}";
    }
}
