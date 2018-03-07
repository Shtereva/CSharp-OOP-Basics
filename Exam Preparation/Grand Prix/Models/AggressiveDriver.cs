using System;
using System.Collections.Generic;

namespace GrandPrix.Models
{
    public class AggressiveDriver : Driver
    {
        public AggressiveDriver(string name, Car car)
            : base(name, car, 2.7)
        {
        }

        public override double Speed => base.Speed * 1.3;

        public override void Overtake(Queue<Driver> overtakings, WeatherType weather, ref bool isSuccess)
        {
            if (this.Car.Tyre is UltrasoftTyre)
            {
                if (Math.Abs(this.TotalTime - overtakings.Peek().TotalTime) <= 3)
                {
                    if (weather == WeatherType.Foggy)
                    {
                        throw new ArgumentException("Crashed");
                    }

                    this.TotalTime -= 3;
                    overtakings.Peek().TotalTime += 3;
                    isSuccess = true;
                }

                return;
            }

            if (Math.Abs(this.TotalTime - overtakings.Peek().TotalTime) <= 2)
            {
                this.TotalTime -= 2;
                overtakings.Peek().TotalTime += 2;
                isSuccess = true;
            }
        }
    }
}

