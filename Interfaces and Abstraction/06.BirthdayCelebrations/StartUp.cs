using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

public class StartUp
{
    public static void Main()
    {
        string input = string.Empty;
        var habitat = new List<IBirthdate>();

        while ((input = Console.ReadLine()) != "End")
        {
            var args = input.Split();

            if (args[0] == "Citizen")
            {
                habitat.Add(new Citizen(args[1], int.Parse(args[2]), args[3], args[4]));
            }

            if (args[0] == "Pet")
            {
                habitat.Add(new Pet(args[1], args[2]));
            }
        }

        input = Console.ReadLine();

        habitat
            .Where(h => h.Birthdate.EndsWith(input))
            .ToList()
            .ForEach(h => Console.WriteLine(h.Birthdate));
    }
}
