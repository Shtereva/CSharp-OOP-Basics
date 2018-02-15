using System;

public class StartUp
{
    public static Shape shape;
    public static void Main()
    {
        string shapes = Console.ReadLine();

        int size = int.Parse(Console.ReadLine());

        if (shapes == "Rectangle")
        {
            int len = int.Parse(Console.ReadLine());

            shape = new Rectangle(size, len);
            var tool = new DrawingTool(shape);
            tool.Tool.Draw();
            return;
        }

        shape = new Square(size);
        shape.Draw();
    }
}
