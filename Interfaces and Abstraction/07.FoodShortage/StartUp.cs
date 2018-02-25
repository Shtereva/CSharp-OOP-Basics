using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var persons = new List<IBuyer>();
        int lines = int.Parse(Console.ReadLine());

        for (int i = 0; i < lines; i++)
        {
            var input = Console.ReadLine().Split();

            if (input.Length == 4)
            {
                persons.Add(new Citizen(input[0], int.Parse(input[1]), input[2], input[3]));
                continue;
            }

            persons.Add(new Rebel(input[0], int.Parse(input[1]), input[2]));
        }

        string buyer = String.Empty;

        while ((buyer = Console.ReadLine()) != "End")
        {
            var person = persons.Find(p => p.Name == buyer);
            if (person != null)
            {
                person.BuyFood();
            }
        }

        Console.WriteLine(persons.Sum(p => p.Food));
    }
}
