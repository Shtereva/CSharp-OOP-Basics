using System.Collections.Generic;

namespace GrandPrix.Models
{
    public abstract class Driver
    {
        private string name;
        private double totalTime;
        private Car car;
        private double fuleConsumption;

        protected Driver(string name, Car car, double fuleConsumption)
        {
            this.Name = name;
            this.Car = car;
            this.totalTime = 0;
            this.FuelConsumptionPerKm = fuleConsumption;

        }

        public string Name
        {
            get => this.name;
            private set
            {
                this.name = value;
            }
        }

        public double TotalTime
        {
            get => this.totalTime;
            set => this.totalTime = value;
        }

        public double FuelConsumptionPerKm
        {
            get => this.fuleConsumption;
            private set => this.fuleConsumption = value;
        }

        public virtual double Speed => (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount;

        public Car Car
        {
            get => this.car;
            set => this.car = value;
        }

        public void Refuel(double liters)
        {
            this.Car.IncreaseFuel(liters);
        }

        public virtual void ReduceFuelAmount(double trackLength)
        {
            double formulaResult = (trackLength * this.FuelConsumptionPerKm);
            this.Car.DecreaseFuel(formulaResult);
            this.Car.Tyre.ReduceDegradation();
        }

        public virtual void Overtake(Queue<Driver> overtakings, WeatherType weather, ref bool isSuccess)
        {
       
        }
    }
}
