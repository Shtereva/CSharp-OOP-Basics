using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {

        var lines = int.Parse(Console.ReadLine());
        var team = new Team("Gorno Nanadolnishte");
        for (int i = 0; i < lines; i++)
        {
            try
            {
                var cmdArgs = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                var person = new Person(cmdArgs[0],
                    cmdArgs[1],
                    int.Parse(cmdArgs[2]),
                    decimal.Parse(cmdArgs[3]));

                team.AddPlayer(person);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        Console.WriteLine(team);
    }
}
