using System;
using System.Collections.Generic;
using System.Linq;
public class StartUp
{
    public static void Main()
    {
        var engines = new List<Engine>();
        var cars = new List<Car>();

        int lines = int.Parse(Console.ReadLine());

        for (int i = 0; i < lines; i++)
        {
            var engineInfo = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            string model = engineInfo[0];
            string power = engineInfo[1];

            var engine = new Engine(model, power);
            AddEngines(engines, engineInfo, engine);
        }

        lines = int.Parse(Console.ReadLine());
        for (int i = 0; i < lines; i++)
        {
            var carInfo = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            string model = carInfo[0];
            string engineModel = carInfo[1];

            var car = new Car(model, engines.First(e => e.Model == engineModel));
            AddCars(cars, carInfo, car);
        }

        cars.ForEach(Console.WriteLine);
    }

    private static void AddCars(List<Car> cars, string[] carInfo, Car car)
    {
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

        cars.Add(car);
    }

    private static void AddEngines(List<Engine> engines, string[] engineInfo, Engine engine)
    {
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

        engines.Add(engine);
    }
}
