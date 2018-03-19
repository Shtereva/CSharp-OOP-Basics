using System;

public class Car
{
    private const double MAX_CAPACITY = 160;

    private int hp;
    private double fuelAmount;
    private Tyre tyre;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public int Hp => this.hp;

    public double FuelAmount
    {
        get => this.fuelAmount;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Out of fuel");
            }
            this.fuelAmount = Math.Min(value, MAX_CAPACITY);
        }
    }

    public Tyre Tyre
    {
        get => this.tyre;
        private set => this.tyre = value;
    }

    public void IncreaseFuel(double liters)
    {
        this.FuelAmount += liters;
    }

    public void DecreaseFuel(double liters)
    {
        this.FuelAmount -= liters;
    }

    public void ChangeTyre(Tyre tyre)
    {
        this.Tyre = tyre;
    }
}
