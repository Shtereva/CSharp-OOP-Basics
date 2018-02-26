public abstract class Animal
{
    protected string animalName;
    protected string animalType;
    protected double animalWeight;
    private int foodEaten;

    public int FoodEaten
    {
        get => this.foodEaten;
        protected set => this.foodEaten = value;
    }

    public Animal(string animalType, string animalName, double animalWeight)
    {
        this.animalName = animalName;
        this.animalType = animalType;
        this.animalWeight = animalWeight;
    }

    public abstract void MakeSound();

    public abstract void Eat(Food food);

    public override string ToString()
    {
        return $"{this.animalType}[{this.animalName}";
    }
}