using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static List<Car> cars;
    public static void Main()
    {
        cars = new List<Car>();
        int lines = Int32.Parse(Console.ReadLine());
        for (int i = 0; i < lines; i++)
        {
            ExecuteCommand.Execute(Console.ReadLine());
        }

        ExecuteCommand.PrintCars();
    }

}
