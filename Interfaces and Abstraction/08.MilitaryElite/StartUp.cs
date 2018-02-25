using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        var soldiers = new List<ISoldier>();
        string input;

        while ((input = Console.ReadLine()) != "End")
        {
            try
            {
                var args = input.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                InputParser.ParseSoldierInfo(args, soldiers);
            }
            catch (Exception e)
            {
                continue;
            }
        }

        soldiers.ForEach(Console.WriteLine);
    }
}
