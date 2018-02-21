using System;

public class Dough
{
    private static decimal caloriesPerGram = 2;

    private string flour;
    private string bakingTechnique;
    private decimal weight;

    private decimal[] flourModifiers = new decimal[] { 1.5m, 1.0m };
    private decimal[] bakingModifiers = new decimal[] { 0.9m, 1.1m, 1.0m };

    public Dough(string flour, string bakingTechnique, decimal weight)
    {
        this.Flour = flour;
        this.BakingTechnique = bakingTechnique;
        this.Weight = weight;
    }

    public string Flour
    {
        get => this.flour;
        private set
        {
            if (!Enum.IsDefined(typeof(FlourType), value.ToLower()))
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            this.flour = value;
        }
    }

    public string BakingTechnique
    {
        get => this.bakingTechnique;
        private set
        {
            if (!Enum.IsDefined(typeof(BakingTechniqueType), value.ToLower()))
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            this.bakingTechnique = value;
        }
    }

    public decimal Weight
    {
        get => this.weight;
        private set
        {
            if (value < 1 || value > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }
            this.weight = value;
        }
    }

    private decimal CalculateCalories()
    {
        decimal flourCalories = flourModifiers[(int)Enum.Parse(typeof(FlourType), this.flour.ToLower())];
        decimal bakingCalories = bakingModifiers[(int)Enum.Parse(typeof(BakingTechniqueType), this.bakingTechnique.ToLower())];

        return (caloriesPerGram * this.weight) * flourCalories * bakingCalories;
    }

    public override string ToString()
    {
        return $"{CalculateCalories():f2}";
    }
}
