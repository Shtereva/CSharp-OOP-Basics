using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var coordinates = Console.ReadLine()
            .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(double.Parse)
            .ToArray();

        var rectangle = new Rectangle(new Point(coordinates[0], coordinates[1]), new Point(coordinates[2], coordinates[3]));

        int lines = int.Parse(Console.ReadLine());

        for (int i = 0; i < lines; i++)
        {
            var input = Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            var point = new Point(input[0], input[1]);

            Console.WriteLine(rectangle.Contains(point));
        }
    }
}
