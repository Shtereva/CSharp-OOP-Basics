using System;

public class Car : Vehicle
{
    public Car(double fuelQuanitity, double fuelConsumptionPerKm, double tankCapacity)
        : base(fuelQuanitity, fuelConsumptionPerKm, tankCapacity)
    {
    }

    public override void Refuel(double liters)
    {
        if (this.FuelQuanitity + liters > this.TankCapacity)
        {
            throw new ArgumentException("Cannot fit fuel in tank");
        }
        base.Refuel(liters);
    }
}