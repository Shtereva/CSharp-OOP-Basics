using System;
using System.Linq;
public class StartUp
{
    public static int[,] galaxy;
    public static void Main()
    {
        FillGalaxyWithNumbers();

        string command = string.Empty;
        long sum = 0;
        while ((command = Console.ReadLine()) != "Let the Force be with you")
        {
            int[] player = command
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] opponent = Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            InstantDestructionOfCells(opponent);
            sum = CollectingStars(sum, player);
        }

        Console.WriteLine(sum);
    }

    private static long CollectingStars(long sum, int[] player)
    {
        int playerRow = player[0];
        int playerCol = player[1];

        while (playerRow >= 0 && playerCol < galaxy.GetLength(1))
        {
            if (playerRow >= 0 && playerRow < galaxy.GetLength(0) && playerCol >= 0 && playerCol < galaxy.GetLength(1))
            {
                sum += galaxy[playerRow, playerCol];
            }

            playerCol++;
            playerRow--;
        }

        return sum;
    }

    private static void InstantDestructionOfCells(int[] opponent)
    {
        int opponentRow = opponent[0];
        int opponentCol = opponent[1];

        while (opponentRow >= 0 && opponentCol >= 0)
        {
            if (opponentRow >= 0 && opponentRow < galaxy.GetLength(0) && opponentCol >= 0 && opponentCol < galaxy.GetLength(1))
            {
                galaxy[opponentRow, opponentCol] = 0;
            }
            opponentRow--;
            opponentCol--;
        }
    }

    private static void FillGalaxyWithNumbers()
    {
        int[] dimestions = Console.ReadLine()
                        .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

        int x = dimestions[0];
        int y = dimestions[1];

        galaxy = new int[x, y];

        int value = 0;
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                galaxy[i, j] = value;
                value++;
            }
        }
    }
}
