using System;

public class Topping
{
    private static decimal caloriesPerGram = 2;

    private string toppingName;
    private decimal weight;

    private decimal[] toppingModifiers = new decimal[] { 1.2m, 0.8m, 1.1m, 0.9m };

    public Topping(string toppingName, decimal weight)
    {
        this.ToppingName = toppingName;
        this.Weight = weight;
    }

    public string ToppingName
    {
        get => this.toppingName;
        private set
        {
            if (!Enum.IsDefined(typeof(ToppingType), value.ToLower()))
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
            this.toppingName = value;
        }
    }

    public decimal Weight
    {
        get => this.weight;
        private set
        {
            if (value < 1 || value > 50)
            {
                throw new ArgumentException($"{this.toppingName} weight should be in the range [1..50].");
            }
            this.weight = value;
        }
    }

    private decimal CalculateCalories()
    {
        decimal toppingCalories = toppingModifiers[(int)Enum.Parse(typeof(ToppingType), this.toppingName.ToLower())];

        return (caloriesPerGram * this.weight) * toppingCalories;
    }

    public override string ToString()
    {
        return $"{CalculateCalories():f2}";
    }

}
