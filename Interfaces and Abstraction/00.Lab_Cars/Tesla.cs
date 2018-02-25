using System;

public class Tesla : IElectricCar, ICar
{
    public string Model { get; }
    public string Color { get; }
    public int Battery { get; }

    public Tesla(string model, string color, int battery)
    {
        this.Battery = battery;
        this.Model = model;
        this.Color = color;
    }

    public string Start()
    {
        return "Engine start";
    }

    public string Stop()
    {
        return "Breaaak!";
    }

    public override string ToString()
    {
        string nl = Environment.NewLine;
        return $"{this.Color} {this.GetType()} {this.Model} with {this.Battery} Batteries{nl}{this.Start()}{nl}{this.Stop()}";
    }
}