using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        string input = String.Empty;
        var cats = new List<Cat>();

        while ((input = Console.ReadLine()) != "End")
        {
            var args = input.Split("".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            if (args[0] == "StreetExtraordinaire")
            {
                cats.Add(new StreetExtraordinaire(args[1], args[0], int.Parse(args[2])));
            }

            if (args[0] == "Siamese")
            {
                cats.Add(new Siamese(args[1], args[0], int.Parse(args[2])));
            }

            if (args[0] == "Cymric")
            {
                cats.Add(new Cymric(args[1], args[0], double.Parse(args[2])));
            }
        }

        string cat = Console.ReadLine();
        Console.WriteLine(cats.Find(c => c.Name == cat));
    }
}
