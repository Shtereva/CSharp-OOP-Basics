using System;

public class StartUp
{
    public static Pizza pizza;
    public static void Main()
    {
        string lines = string.Empty;

        try
        {
            while ((lines = Console.ReadLine()) != "END")
            {
                var input = lines.Split(" ".ToCharArray(), StringSplitOptions.None);

                CreatePizza(input);
            }

            if (pizza != null) Console.WriteLine(pizza);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private static void CreatePizza(string[] input)
    {
        switch (input[0].ToLower())
        {
            case "pizza":
                pizza = new Pizza(input[1]);
                break;
            case "dough":
                var dought = new Dough(input[1], input[2], decimal.Parse(input[3]));
                if (pizza == null)
                {
                    Console.WriteLine($"{decimal.Parse(dought.ToString()):f2}");
                    return;
                }
                pizza.Dough = dought;
                break;
            case "topping":
                var topping = new Topping(input[1], decimal.Parse(input[2]));
                if (pizza == null)
                {
                    Console.WriteLine($"{decimal.Parse(topping.ToString()):f2}");
                    return;
                }
                pizza.AddTopping(topping);
                break;
        }
    }
}
