using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

public class StartUp
{
    public static void Main()
    {
        string animalType = string.Empty;
        var animals = new List<Animal>();

        while ((animalType = Console.ReadLine()) != "Beast!")
        {
            try
            {
                Animal animal = Factory.CreateInstance(animalType);
                if (animal == null)
                {
                    throw new ArgumentException("Invalid input!");
                }
                animals.Add(animal);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        animals
            .ForEach(x => Console.WriteLine($"{x.GetType()}{Environment.NewLine}{x}"));
    }
}
