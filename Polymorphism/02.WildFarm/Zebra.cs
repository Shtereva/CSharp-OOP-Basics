using System;

public class Zebra : Mammal
{
    public Zebra(string animalType, string animalName, double animalWeight, string livingRegion)
        : base(animalType, animalName, animalWeight, livingRegion)
    {
    }

    public override void MakeSound()
    {
        Console.WriteLine("Zs");
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