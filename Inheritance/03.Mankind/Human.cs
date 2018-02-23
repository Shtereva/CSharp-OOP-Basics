using System;

public class Human
{
    protected string firstName;
    protected string lastName;

    public Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public string FirstName
    {
        get => this.firstName;
        set
        {
            if (!char.IsUpper(value[0]))
            {
                throw new ArgumentException($"Expected upper case letter! Argument: firstName");
            }

            if (value.Length <= 3)
            {
                throw new ArgumentException($"Expected length at least 4 symbols! Argument: firstName");
            }
            this.firstName = value;
        }
    }

    public string LastName
    {
        get => this.lastName;
        set
        {
            if (!char.IsUpper(value[0]))
            {
                throw new ArgumentException($"Expected upper case letter! Argument: lastName");
            }

            if (value.Length <= 2)
            {
                throw new ArgumentException($"Expected length at least 3 symbols! Argument: lastName");
            }
            this.lastName = value;
        }
    }

    public override string ToString()
    {
        string nl = Environment.NewLine;
        return $"First Name: {this.firstName}{nl}Last Name: {this.lastName}{nl}";
    }
}
