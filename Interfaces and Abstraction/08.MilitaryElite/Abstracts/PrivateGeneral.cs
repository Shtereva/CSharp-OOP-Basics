public abstract class PrivateGeneral : SoldierGeneral, IPrivate
{
    public double Salary { get; set; }

    public PrivateGeneral(string id, string firstName, string lastName, double salary)
        : base(id, firstName, lastName)
    {
        this.Salary = salary;
    }

    public override string ToString()
    {
        return $"{base.ToString()} Salary: {this.Salary:f2}";
    }
}
