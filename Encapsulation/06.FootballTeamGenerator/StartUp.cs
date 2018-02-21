using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static List<Team> teams;
    public static void Main()
    {
        string input = String.Empty;
        teams = new List<Team>();

        while ((input = Console.ReadLine()) != "END")
        {
            var args = input.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            try
            {
                ManageTeam(args);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    private static void ManageTeam(string[] args)
    {
        switch (args[0])
        {
            case "Team":
                var team = new Team(args[1]);
                teams.Add(team);
                break;
            case "Add":
                if (!teams.Any(t => t.Name == args[1]))
                {
                    throw new ArgumentException($"Team {args[1]} does not exist.");
                }

                var stats = new Stats(double.Parse(args[3]), double.Parse(args[4]), double.Parse(args[5]), double.Parse(args[6]), double.Parse(args[7]));

                teams.Single(t => t.Name == args[1]).AddPlayer(new Player(stats, args[2]));
                break;
            case "Remove":
                teams.Single(t => t.Name == args[1]).RemovePlayer(args[2]);
                break;
            case "Rating":
                if (teams.All(t => t.Name != args[1]))
                {
                    throw new ArgumentException($"Team {args[1]} does not exist.");
                }
                Console.WriteLine($"{teams.Single(t => t.Name == args[1]).Name} - {teams.Single(t => t.Name == args[1]).Rating()}");
                break;
        }
    }
}
