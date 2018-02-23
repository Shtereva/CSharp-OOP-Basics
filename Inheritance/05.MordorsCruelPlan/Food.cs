using System;

public class Food : FoodFactory
{
    private int points;

    public Food()
    {
        this.points = 0;
    }

    public override int GetFood(string[] input)
    {
        foreach (var item in input)
        {
            FoodType food;

            var hasParsed = Enum.TryParse<FoodType>(item.ToLower(), out food);
            this.points += hasParsed ? (int) food : -1;
        }

        return this.points;
    }
}
