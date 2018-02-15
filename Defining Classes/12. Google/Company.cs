using System;
public class Company
{
    private string name;
    private string department;
    private decimal salary;

    public Company(string name, string department, decimal salary)
    {
        this.name = name;
        this.department = department;
        this.salary = salary;
    }

    public override string ToString()
    {
        string nl = Environment.NewLine;

        return $"{nl}{this.name} {this.department} {this.salary:f2}";
    }
}
