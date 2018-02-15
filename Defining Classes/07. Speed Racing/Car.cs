using System;
public class Car
{
    private string model;
    private double fuelAmount;
    private double fuelConsumption;
    private double distanceTraveled;

    public Car(string model, double fuelAmount, double fuelConsumption)
    {
        this.model = model;
        this.fuelAmount = fuelAmount;
        this.fuelConsumption = fuelConsumption;
        this.distanceTraveled = 0;
    }

    public void Dive(double amountOfKm)
    {
        if (amountOfKm * fuelConsumption <= fuelAmount)
        {
            this.fuelAmount -= amountOfKm * fuelConsumption;
            this.distanceTraveled += amountOfKm;
        }

        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
    }

    public override string ToString()
    {
        return $"{this.model} {this.fuelAmount:f2} {this.distanceTraveled}";
    }
}

