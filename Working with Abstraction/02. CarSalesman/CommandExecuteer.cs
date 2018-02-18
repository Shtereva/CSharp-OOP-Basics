using System;
using System.Linq;

public static class CommandExecuteer
{
    public static void AddEngines(string input)
    {
        var engineInfo = input.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

        string model = engineInfo[0];
        string power = engineInfo[1];

        var engine = new Engine(model, power);

        if (engineInfo.Length == 3)
        {
            if (int.TryParse(engineInfo[2], out int result))
            {
                engine.Displacement = engineInfo[2];
            }

            else
            {
                engine.Efficiency = engineInfo[2];
            }
        }

        if (engineInfo.Length == 4)
        {
            engine.Displacement = engineInfo[2];
            engine.Efficiency = engineInfo[3];
        }

        StartUp.engines.Add(engine);
    }

    public static void AddCars(string input)
    {
        var carInfo = input.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

        string model = carInfo[0];
        string engineModel = carInfo[1];

        var car = new Car(model, StartUp.engines.First(e => e.Model == engineModel));

        if (carInfo.Length == 3)
        {
            if (int.TryParse(carInfo[2], out int result))
            {
                car.Weight = carInfo[2];
            }

            else
            {
                car.Color = carInfo[2];
            }
        }

        if (carInfo.Length == 4)
        {
            car.Weight = carInfo[2];
            car.Color = carInfo[3];
        }

        StartUp.cars.Add(car);
    }
}
