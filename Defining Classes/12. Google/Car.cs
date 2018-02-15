using System;

public class Car
{
    private string model;
    private int speed;

    public Car(string model, int speed)
    {
        this.model = model;
        this.speed = speed;
    }

    public override string ToString()
    {
        string nl = Environment.NewLine;

        return $"{nl}{this.model} {this.speed}";
    }
}
