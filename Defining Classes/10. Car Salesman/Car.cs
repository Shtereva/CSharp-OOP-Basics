using System;
public class Car
{
    private string model;
    private Engine engine;
    private string weight;
    private string color;

    public Car(string model, Engine engine)
    {
        this.model = model;
        this.engine = engine;
        this.weight = "n/a";
        this.color = "n/a";
    }
    public string Weight
    {
        set { this.weight = value; }
    }

    public string Color
    {
        set { this.color = value; }
    }

    public override string ToString()
    {
        string nl = Environment.NewLine;
        return $"{this.model}:{nl} {this.engine}{nl} Weight: {this.weight}{nl} Color: {this.color}";
    }
}
