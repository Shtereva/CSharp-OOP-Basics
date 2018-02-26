using System;

public class StartUp
{
    public static void Main()
    {
        bool isLineEven = true;
        Animal animal = null;

        string input;

        while ((input = Console.ReadLine()) != "End")
        {
            var args = input.Split();
            if (!isLineEven)
            {
                Food food = args[0] == "Vegetable" ? (Food)new Vegetable(int.Parse(args[1])) : new Meat(int.Parse(args[1]));

                animal.MakeSound();
                try
                {
                    animal.Eat(food);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine(animal);

                isLineEven = true;
                continue;
            }

            animal = GetAnimalType(args);

            isLineEven = false;
        }
    }

    private static Animal GetAnimalType(string[] args)
    {
        switch (args[0])
        {
            case "Mouse":
                return new Mouse(args[0], args[1], double.Parse(args[2]), args[3]);

            case "Zebra":
                return new Zebra(args[0], args[1], double.Parse(args[2]), args[3]);

            case "Tiger":
                return new Tiger(args[0], args[1], double.Parse(args[2]), args[3]);

            case "Cat":
                return new Cat(args[0], args[1], double.Parse(args[2]), args[3], args[4]);
        }

        return null;
    }
}