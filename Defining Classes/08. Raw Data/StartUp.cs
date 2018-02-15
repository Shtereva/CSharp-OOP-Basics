using System;
using System.Collections.Generic;
using System.Linq;
public class StartUp
{
    public static void Main()
    {
        int carsToTrack = int.Parse(Console.ReadLine());
        var cars = new List<Car>();

        for (int i = 0; i < carsToTrack; i++)
        {
            var carInfo = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            var engine = new Engine(int.Parse(carInfo[1]), int.Parse(carInfo[2]));
            var cargo = new Cargo(int.Parse(carInfo[3]), carInfo[4]);
            var tires = new Tire[]
            {
                    new Tire(double.Parse(carInfo[5]), int.Parse(carInfo[6])),
                    new Tire(double.Parse(carInfo[7]), int.Parse(carInfo[8])),
                    new Tire(double.Parse(carInfo[9]), int.Parse(carInfo[10])),
                    new Tire(double.Parse(carInfo[11]), int.Parse(carInfo[12])),
            };

            var car = new Car(carInfo[0], engine, cargo, tires);
            cars.Add(car);
        }

        switch (Console.ReadLine())
        {
            case "fragile":
                cars
                    .Where(c => c.Cargo.CargoType == "fragile" && c.Tires.Any(t => t.Pressure < 1))
                    .ToList()
                    .ForEach(c => Console.WriteLine(c.Model));
                break;
            case "flamable":
                cars
                    .Where(c => c.Cargo.CargoType == "flamable" && c.Engine.EnginePower > 250)
                    .ToList()
                    .ForEach(c => Console.WriteLine(c.Model));
                break;
        }
    }
}
