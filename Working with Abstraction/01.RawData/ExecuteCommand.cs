using System;
using System.Collections.Generic;
using System.Linq;

public static class ExecuteCommand
{
    public static void Execute(string input)
    {
        string[] parameters = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        ParseCarAtributes(parameters);
    }

    private static void ParseCarAtributes(string[] parameters)
    {
        var engine = new Engine(int.Parse(parameters[1]), int.Parse(parameters[2]));
        var cargo = new Cargo(int.Parse(parameters[3]), Enum.Parse<CargoType>(parameters[4]));
        var tires = new Tire[]
        {
            new Tire(double.Parse(parameters[5]), int.Parse(parameters[6])),
            new Tire(double.Parse(parameters[7]), int.Parse(parameters[8])),
            new Tire(double.Parse(parameters[9]), int.Parse(parameters[10])),
            new Tire(double.Parse(parameters[11]), int.Parse(parameters[12])),
        };

        var car = new Car(parameters[0], engine, cargo, tires);
        StartUp.cars.Add(car);
    }

    public static void PrintCars()
    {
        var command = Enum.Parse<CargoType>(Console.ReadLine());
        Func<Car, bool>[] condicions = new Func<Car, bool>[2];
        condicions[0] = (c) => c.Tires.Any(t => t.Pressure < 1);
        condicions[1] = (c) => c.Engine.EnginePower > 250;

        StartUp.cars
            .Where(c => c.Cargo.CargoType == command && condicions[(int)command](c))
            .ToList()
            .ForEach(c => Console.WriteLine(c.Model));
    }
}
