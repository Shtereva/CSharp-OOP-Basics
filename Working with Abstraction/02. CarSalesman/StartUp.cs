using System;
using System.Collections.Generic;
using System.Linq;
public class StartUp
{
    public static List<Engine> engines;
    public static List<Car> cars;
    public static void Main()
    {
        engines = new List<Engine>();
        cars = new List<Car>();

        int lines = int.Parse(Console.ReadLine());
        for (int i = 0; i < lines; i++)
        {
            CommandExecuteer.AddEngines(Console.ReadLine());
        }

        lines = int.Parse(Console.ReadLine());
        for (int i = 0; i < lines; i++)
        {
            CommandExecuteer.AddCars(Console.ReadLine());
        }

        cars.ForEach(Console.WriteLine);
    }
}
