using System;

public class Truck : Vehicle
{
    public Truck(double fuelQuanitity, double fuelConsumptionPerKm, double tankCapacity)
        : base(fuelQuanitity, fuelConsumptionPerKm, tankCapacity)
    {
        this.FuelConsumptionPerKm += 1.6;
    }

    public override void Refuel(double liters)
    {
        if (liters <= 0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }

        if (this.FuelQuanitity + (liters - (liters * 0.05)) > this.TankCapacity)
        {
			throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
		}
        this.FuelQuanitity += (liters - (liters * 0.05));
    }
}