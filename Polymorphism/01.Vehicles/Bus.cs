using System;

public class Bus : Vehicle
{
    public Bus(double fuelQuanitity, double fuelConsumptionPerKm, double tankCapacity)
        : base(fuelQuanitity, fuelConsumptionPerKm, tankCapacity)
    {
        this.FuelConsumptionPerKm += 1.4;
    }

    public override void Refuel(double liters)
    {
        if (liters <= 0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }

        if (this.FuelQuanitity + liters > this.TankCapacity)
        {
            throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
        }
        base.Refuel(liters);
    }
}