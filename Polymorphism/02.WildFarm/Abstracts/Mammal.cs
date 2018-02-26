public abstract class Mammal : Animal
{
    private string livingRegion;

    public Mammal(string animalType, string animalName, double animalWeight, string livingRegion)
        : base(animalType, animalName, animalWeight)
    {
        this.livingRegion = livingRegion;
    }

    public string LivingRegion
    {
        get => this.livingRegion;
        set => this.livingRegion = value;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, {this.animalWeight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}