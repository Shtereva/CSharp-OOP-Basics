using System;
using System.Collections.Generic;
using System.Linq;
public class StartUp
{
    public static void Main()
    {
        var input = Console.ReadLine()
            .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(double.Parse)
            .ToArray();

        double numberOfRectangles = input[0];
        double intersectionsChecks = input[1];

        var rectangles = new List<Rectangle>();

        for (int i = 0; i < numberOfRectangles; i++)
        {
            var args = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            string id = args[0];
            double width = double.Parse(args[1]);
            double height = double.Parse(args[2]);
            double x = double.Parse(args[3]);
            double y = double.Parse(args[4]);

            var coordinates = new Point(x, y);
            var rectangle = new Rectangle(id, width, height, coordinates);
            rectangles.Add(rectangle);
        }

        for (int i = 0; i < intersectionsChecks; i++)
        {
            var args = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            var firstRect = rectangles.Find(x => x.Id == args[0]);
            var secondRect = rectangles.Find(x => x.Id == args[1]);

            if (firstRect == null || secondRect == null)
            {
                Console.WriteLine("false");
            }

            Console.WriteLine(firstRect.Intersect(secondRect) ? "true" : "false");
        }
    }
}
