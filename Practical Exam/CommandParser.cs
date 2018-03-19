using System;
using System.Linq;

namespace DungeonsAndCodeWizards
{
    public class CommandParser
    {
        public void Execute()
        {
            string input = Console.ReadLine();
            bool isGameOver = false;
            string finalStatus = String.Empty;
            var dungeonMaster = new DungeonMaster();

            while (!string.IsNullOrWhiteSpace(input))
            {
                var cmdArgs = input.Split();

                string command = cmdArgs[0];
                cmdArgs = cmdArgs.Skip(1).ToArray();
                string result = String.Empty;

                try
                {
                    switch (command)
                    {
                        case "JoinParty":
                            result = dungeonMaster.JoinParty(cmdArgs);
                            break;
                        case "AddItemToPool":
                            result = dungeonMaster.AddItemToPool(cmdArgs);
                            break;
                        case "PickUpItem":
                            result = dungeonMaster.PickUpItem(cmdArgs);
                            break;
                        case "UseItem":
                            result = dungeonMaster.UseItem(cmdArgs);
                            break;
                        case "UseItemOn":
                            result = dungeonMaster.UseItemOn(cmdArgs);
                            break;
                        case "GiveCharacterItem":
                            result = dungeonMaster.GiveCharacterItem(cmdArgs);
                            break;
                        case "GetStats":
                            result = dungeonMaster.GetStats();
                            break;
                        case "Attack":
                            result = dungeonMaster.Attack(cmdArgs);
                            break;
                        case "Heal":
                            result = dungeonMaster.Heal(cmdArgs);
                            break;
                        case "EndTurn":
                            result = dungeonMaster.EndTurn(cmdArgs);
                            break;
                        case "IsGameOver":
                            isGameOver = dungeonMaster.IsGameOver();
                            break;
                    }
                }
                catch (Exception e)
                {
                    result = e is ArgumentException ? "Parameter Error: " + e.Message : "Invalid Operation: " + e.Message;
                }

                if (isGameOver)
                {
                    break;
                }

                Console.WriteLine(result);
                input = Console.ReadLine();
            }

            Console.WriteLine($"Final stats: {Environment.NewLine}{dungeonMaster.GetStats()}");
        }
    }
}
