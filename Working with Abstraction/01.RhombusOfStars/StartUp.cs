using System;
using System.Text;

public class StartUp
{
    public static StringBuilder rhombus;
    public static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        rhombus = new StringBuilder();
        int helper = 1;

        for (int i = 0; i < size * 2 - 1; i++)
        {
            int spaces = i <= size - 1 ? size - 1 - i : i - size + 1;
            int stars = i <= size - 1 ? i + 1 : i - helper;
            helper = i <= size - 1 ? 1 : helper + 2;
            PrintRow(spaces, stars);
        }

        Console.WriteLine(rhombus);
    }

    private static void PrintRow(int spaces, int stars)
    {
        string line = $"{new string(' ', spaces)}{new string('*', stars)}";
        line = line.Replace("*", "* ").TrimEnd();
        rhombus.AppendLine(line);
    }
}
