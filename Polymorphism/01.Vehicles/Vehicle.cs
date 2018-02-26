using System;

public abstract class Vehicle : IVehicle
{
    private double fuelQuanitity;
    private double fuelConsumptionPerKm;
    private double tankCapacity;

    public Vehicle(double fuelQuanitity, double fuelConsumptionPerKm, double tankCapacity)
    {
        this.FuelQuanitity = fuelQuanitity;
        this.FuelConsumptionPerKm = fuelConsumptionPerKm;
        this.TankCapacity = tankCapacity;
    }

    public double FuelQuanitity
    {
        get => this.fuelQuanitity;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            this.fuelQuanitity = value;
        }
    }

    public double FuelConsumptionPerKm
    {
        get => this.fuelConsumptionPerKm;
        set { this.fuelConsumptionPerKm = value; }
    }

    public double TankCapacity
    {
        get => this.tankCapacity;
        set => this.tankCapacity = value;
    }

    public virtual string Drive(double distance)
    {
        double consumption = distance * this.FuelConsumptionPerKm;
        if (this.FuelQuanitity >= consumption)
        {
            this.FuelQuanitity -= consumption;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        return $"{this.GetType().Name} needs refueling";
    }

    public virtual void Refuel(double liters)
    {
        this.FuelQuanitity += liters;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {this.FuelQuanitity:f2}";
    }
}