using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        var accounts = new Dictionary<int, BankAccount>();

        string input = String.Empty;

        while ((input = Console.ReadLine()) != "End")
        {
            var cmdArg = input.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            string command = cmdArg[0];


            switch (command)
            {
                case "Create":
                    Create(cmdArg, accounts);
                    break;
                case "Deposit":
                    Deposit(cmdArg, accounts);
                    break;
                case "Withdraw":
                    Withdraw(cmdArg, accounts);
                    break;
                case "Print":
                    Print(cmdArg, accounts);
                    break;
            }
        }
    }

    private static void Print(string[] cmdArg, Dictionary<int, BankAccount> accounts)
    {
        int id = int.Parse(cmdArg[1]);

        if (accounts.ContainsKey(id))
        {
            Console.WriteLine(accounts[id]);
        }

        else
        {
            Console.WriteLine("Account does not exist");
        }
    }

    private static void Withdraw(string[] cmdArg, Dictionary<int, BankAccount> accounts)
    {
        int id = int.Parse(cmdArg[1]);
        decimal amount = cmdArg.Length == 3 ? decimal.Parse(cmdArg[2]) : 0;

        if (accounts.ContainsKey(id))
        {
            if (accounts[id].Balance - amount >= 0)
            {
                accounts[id].Balance -= amount;
            }

            else
            {
                Console.WriteLine("Insufficient balance");
            }
        }

        else
        {
            Console.WriteLine("Account does not exist");
        }
    }

    private static void Deposit(string[] cmdArg, Dictionary<int, BankAccount> accounts)
    {
        int id = int.Parse(cmdArg[1]);
        decimal balance = cmdArg.Length == 3 ? decimal.Parse(cmdArg[2]) : 0;

        if (accounts.ContainsKey(id))
        {
            accounts[id].Balance += balance;
        }

        else
        {
            Console.WriteLine("Account does not exist");
        }

    }

    private static void Create(string[] cmdArg, Dictionary<int, BankAccount> accounts)
    {
        int id = int.Parse(cmdArg[1]);

        if (!accounts.ContainsKey(id))
        {
            accounts[id] = new BankAccount { ID = id };
        }

        else
        {
            Console.WriteLine("Account already exists");
        }
    }
}
