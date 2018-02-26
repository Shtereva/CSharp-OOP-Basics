public class Truck : Vehicle
{
    public Truck(double fuelQuanitity, double fuelConsumptionPerKm, double tankCapacity)
        : base(fuelQuanitity, fuelConsumptionPerKm, tankCapacity)
    {
        this.FuelConsumptionPerKm += 1.6;
    }

    public override void Refuel(double liters)
    {
        this.FuelQuanitity += (liters - (liters * 0.05));
    }
}