using System;

public class StartUp
{
    public static void Main()
    {
        string firstDate = Console.ReadLine();
        string secondDate = Console.ReadLine();

        var dateModifier = new DateModifier();
        dateModifier.GetDiiffInDays(firstDate, secondDate);
        Console.WriteLine(dateModifier.Diff);
    }
}
