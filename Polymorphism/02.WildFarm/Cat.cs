using System;

public class Cat : Felime
{
    private string breed;

    public Cat(string animalName, string animalType, double animalWeight, string livingRegion, string breed)
        : base(animalName, animalType, animalWeight, livingRegion)
    {
        this.breed = breed;
    }

    public override void MakeSound()
    {
        Console.WriteLine("Meowwww");
    }

    public override void Eat(Food food)
    {
        this.FoodEaten += food.Quantity;
    }

    public override string ToString()
    {
        return $"{this.animalType}[{this.animalName}, {this.breed}, {this.animalWeight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}