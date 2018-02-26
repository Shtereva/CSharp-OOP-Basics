using System;

public class Tiger : Felime
{
    public Tiger(string animalName, string animalType, double animalWeight, string livingRegion)
        : base(animalName, animalType, animalWeight, livingRegion)
    {
    }

    public override void MakeSound()
    {
        Console.WriteLine("ROAAR!!!");
    }

    public override void Eat(Food food)
    {
        if (food is Meat)
        {
            this.FoodEaten += food.Quantity;
        }
        else
        {
            throw new ArgumentException($"{this.GetType().Name}s are not eating that type of food!");
        }
    }
}