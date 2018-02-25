using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        string input = String.Empty;
        var habitat = new List<IHabitat>();

        while ((input = Console.ReadLine()) != "End")
        {
            var args = input.Split();

            if (args.Length == 3)
            {
                habitat.Add(new Citizen(args[0], int.Parse(args[1]), args[2]));
                continue;
            }

            habitat.Add(new Robot(args[0], args[1]));
        }

        input = Console.ReadLine();

        habitat
            .Where(h => h.Id.EndsWith(input))
            .ToList()
            .ForEach(h => Console.WriteLine(h.Id));
    }
}
