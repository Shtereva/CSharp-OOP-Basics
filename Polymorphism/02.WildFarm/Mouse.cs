using System;

public class Mouse : Mammal
{
    public Mouse(string animalType, string animalName, double animalWeight, string livingRegion)
        : base(animalType, animalName, animalWeight, livingRegion)
    {
    }

    public override void MakeSound()
    {
        Console.WriteLine("SQUEEEAAAK!");
    }

    public override void Eat(Food food)
    {
        if (food is Vegetable)
        {
            this.FoodEaten += food.Quantity;
        }
        else
        {
            throw new ArgumentException($"{this.GetType().Name}s are not eating that type of food!");
        }
    }
}