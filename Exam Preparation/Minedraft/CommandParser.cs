using System;
using System.Linq;

public class CommandParser
{
    public void Execute()
    {
        var draftManager = new DraftManager();

        while (true)
        {
            var input = Console.ReadLine().Split();
            string command = input[0];

            var arguments = input.Skip(1).ToList();
            string result = string.Empty;

            try
            {
                switch (command)
                {
                    case "RegisterHarvester":
                        result = draftManager.RegisterHarvester(arguments);
                        break;
                    case "RegisterProvider":
                        result = draftManager.RegisterProvider(arguments);
                        break;
                    case "Day":
                        result = draftManager.Day();
                        break;
                    case "Mode":
                        result = draftManager.Mode(arguments);
                        break;
                    case "Check":
                        result = draftManager.Check(arguments);
                        break;
                    case "Shutdown":
                        result = draftManager.ShutDown();
                        Console.WriteLine(result);
                        return;
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                continue;
            }

            Console.WriteLine(result);
        }
    }
}
