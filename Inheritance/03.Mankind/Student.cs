using System;
using System.Linq;

public class Student : Human
{
    private string facultyNumber;

    public Student(string firstName, string lastName, string facultyNumber) 
        : base(firstName, lastName)
    {
        this.FacultyNumber = facultyNumber;
    }

    public string FacultyNumber
    {
        get => this.facultyNumber;
        set
        {
            if (value.Length < 5 || value.Length > 10 || value.Any(c => !char.IsLetterOrDigit(c)))
            {
                throw new ArgumentException("Invalid faculty number!");
            }
            this.facultyNumber = value;
        }
    }

    public override string ToString()
    {
        return $"{base.ToString()}Faculty number: {this.FacultyNumber}{Environment.NewLine}";
    }
}
