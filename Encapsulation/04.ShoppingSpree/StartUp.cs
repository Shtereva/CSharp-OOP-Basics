using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var products = new List<Product>();
        var people = new List<Person>();

        try
        {
            var peopleInput = Console.ReadLine().Split("=;".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            AddPeople(people, peopleInput);

            var productsInput = Console.ReadLine().Split("=;".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            AddProducts(products, productsInput);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
            return;
        }

        string input = String.Empty;
        while ((input = Console.ReadLine()) != "END")
        {
            var purchuase = input.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            var person = people.SingleOrDefault(p => p.Name == purchuase[0]);
            var product = products.SingleOrDefault(p => p.Name == purchuase[1]);

            if (person.CheckIfPersonCanAffortProduct(product.Cost))
            {
                Console.WriteLine($"{purchuase[0]} bought {purchuase[1]}");
                person.AddProduct(product);
                continue;
            }

            Console.WriteLine($"{purchuase[0]} can't afford {purchuase[1]}");
        }

        people.ForEach(Console.WriteLine);
    }

    private static void AddProducts(List<Product> products, string[] productsInput)
    {
        for (var i = 0; i < productsInput.Length; i += 2)
        {
            products.Add(new Product(productsInput[i], decimal.Parse(productsInput[i + 1])));
        }
    }

    private static void AddPeople(List<Person> people, string[] peopleInput)
    {
        for (var i = 0; i < peopleInput.Length; i += 2)
        {
            people.Add(new Person(peopleInput[i], decimal.Parse(peopleInput[i + 1])));
        }
    }
}
