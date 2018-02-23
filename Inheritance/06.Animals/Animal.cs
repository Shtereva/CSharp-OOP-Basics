using System;
using System.Linq;
using System.Text;

public abstract class Animal : ISoundProducable
{
    private string name;
    private string age;
    private string gender;

    public Animal(string name, string age, string gender)
    {
        this.Name = name;
        this.Age = age;
        this.Gender = gender;
    }

    public string Name
    {
        get => this.name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid input!");
            }
            this.name = value;
        }
    }

    public string Age
    {
        get => this.age;
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Any(c => !char.IsDigit(c)))
            {
                throw new ArgumentException("Invalid input!");
            }
            this.age = value;
        }
    }

    public string Gender
    {
        get => this.gender;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid input!");
            }
            this.gender = value;
        }
    }

    public abstract string ProduceSound();

    public override string ToString()
    {
        return $"{this.Name} {this.Age} {this.Gender}{Environment.NewLine}{this.ProduceSound()}";
    }
}
