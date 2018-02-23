using System;

public class Worker : Human
{
    private decimal weekSalary;
    private decimal workHoursPerDay;

    public Worker(string firstName, string lastName, decimal weekSalary, decimal workHoursPerDay) 
        : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workHoursPerDay;
    }

    public decimal WeekSalary
    {
        get => this.weekSalary;
        set
        {
            if (value <= 10)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }
            this.weekSalary = value;
        }
    }

    public decimal WorkHoursPerDay
    {
        get => this.workHoursPerDay;
        set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }
            this.workHoursPerDay = value;
        }
    }

    public override string ToString()
    {
        string nl = Environment.NewLine;
        decimal salaryPerHour = this.WeekSalary / (this.workHoursPerDay * 5);
        return $"{base.ToString()}Week Salary: {this.WeekSalary:f2}{nl}Hours per day: {this.WorkHoursPerDay:f2}{nl}Salary per hour: {salaryPerHour:f2}";
    }
}
