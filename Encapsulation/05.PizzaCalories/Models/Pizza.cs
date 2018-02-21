using System;
using System.Collections.Generic;
using System.Linq;

public class Pizza
{
    private string name;
    private Dough dough;
    private List<Topping> toppings;

    public Pizza(string name)
    {
        this.Name = name;
        this.toppings = new List<Topping>();
    }

    public string Name
    {
        get => this.name;
        private set
        {
            if (value.Length < 1 || value.Length > 15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }

            this.name = value;
        }
    }

    public Dough Dough { get => dough; set => dough = value; }

    public int NumberOfToppings => this.toppings.Count;

    public decimal TotalCalories
    {
        get
        {
            if (!this.toppings.Any())
            {
                return decimal.Parse(this.dough.ToString());
            }
            return decimal.Parse(this.dough.ToString()) + this.toppings.Sum(t => decimal.Parse(t.ToString()));
        }
    }

    public void AddTopping(Topping topping)
    {
        if (this.toppings.Count >= 10)
        {
            throw new ArgumentException("Number of toppings should be in range [0..10].");
        }
        this.toppings.Add(topping);
    }

    public override string ToString()
    {
        return $"{this.name} - {this.TotalCalories:f2} Calories.";
    }
}
