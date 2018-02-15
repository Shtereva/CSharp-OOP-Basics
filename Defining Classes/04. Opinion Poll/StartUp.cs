using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main(string[] args)
    {
        int lines = int.Parse(Console.ReadLine());
        var persons = new List<Person>();

        for (int i = 0; i < lines; i++)
        {
            var input = Console.ReadLine().Split();

            string name = input[0];
            int age = int.Parse(input[1]);

            persons.Add(new Person(name, age));
        }

        persons
            .Where(x => x.Age > 30)
            .OrderBy(x => x.Name)
            .ToList()
            .ForEach(x => Console.WriteLine($"{x.Name} - {x.Age}"));
    }
}
