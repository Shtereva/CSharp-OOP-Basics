using System;
using System.Linq;

namespace GrandPrix
{
    public class CommandParser
    {
        public void Execute()
        {
            var raceTower = new RaceTower();
            int laps = int.Parse(Console.ReadLine());
            int trackLength = int.Parse(Console.ReadLine());

            raceTower.SetTrackInfo(laps, trackLength);
            string result = string.Empty;

            while (raceTower.CompletedLaps < laps)
            {
                var input = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                string command = input[0];
                var commandArgs = input.Skip(1).ToList();

                try
                {
                    switch (command)
                    {
                        case "RegisterDriver":
                            raceTower.RegisterDriver(commandArgs);
                            break;
                        case "Leaderboard":
                            Console.WriteLine(raceTower.GetLeaderboard());
                            break;
                        case "CompleteLaps":
                            result = raceTower.CompleteLaps(commandArgs);
                            break;
                        case "Box":
                            raceTower.DriverBoxes(commandArgs);
                            break;
                        case "ChangeWeather":
                            raceTower.ChangeWeather(commandArgs);
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine(result);

        }
    }
}
