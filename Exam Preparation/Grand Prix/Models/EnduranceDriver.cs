using System;
using System.Collections.Generic;

namespace GrandPrix.Models
{
    public class EnduranceDriver : Driver
    {
        public EnduranceDriver(string name, Car car)
            : base(name, car, 1.5)
        {
        }

        public override void Overtake(Queue<Driver> overtakings, WeatherType weather, ref bool isSuccess)
        {
            if (this.Car.Tyre is HardTyre)
            {
                if (Math.Abs(this.TotalTime - overtakings.Peek().TotalTime) <= 3)
                {
                    if (weather == WeatherType.Rainy)
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
