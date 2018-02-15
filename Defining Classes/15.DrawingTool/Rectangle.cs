using System;

public class Rectangle : Shape
{
    private int width;
    private int length;

    public Rectangle(int width, int length)
    {
        this.width = width;
        this.length = length;
    }

    public override void Draw()
    {
        for (int i = 0; i < this.length; i++)
        {
            if (i == 0 || i == this.length - 1)
            {
                Console.WriteLine($"|{new string('-', this.width)}|");
                continue;
            }

            Console.WriteLine($"|{new string(' ', this.width)}|");
        }
    }
}
