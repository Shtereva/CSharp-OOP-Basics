using System;
public class StartUp
{
    public static char[][] room;
    public static void Main()
    {
        FillRoom();

        var directions = Console.ReadLine().ToCharArray();

        int[] playerPosition = new int[2];
        FindPlayerPosition(playerPosition);

        for (int i = 0; i < directions.Length; i++)
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'b')
                    {
                        MoveEnemyB(row, col);
                        break;
                    }
                    if (room[row][col] == 'd')
                    {
                        MoveEnemyD(row, col);
                        break;
                    }
                }
            }

            int[] enemyPosition = new int[2];
            GetEnemyPossition(playerPosition, enemyPosition);

            CheckPlayerPosition(playerPosition, enemyPosition);
            MovePlayer(directions, playerPosition, i);

            GetEnemyPossition(playerPosition, enemyPosition);
            CheckEnemyPosition(playerPosition, enemyPosition);
        }
    }

    private static void CheckEnemyPosition(int[] playerPosition, int[] enemyPosition)
    {
        if (room[enemyPosition[0]][enemyPosition[1]] == 'N' && playerPosition[0] == enemyPosition[0])
        {
            room[enemyPosition[0]][enemyPosition[1]] = 'X';
            Console.WriteLine("Nikoladze killed!");

            PrintRoom();
        }
    }

    private static void MovePlayer(char[] directions, int[] playerPosition, int i)
    {
        room[playerPosition[0]][playerPosition[1]] = '.';
        switch (directions[i])
        {
            case 'U':
                playerPosition[0]--;
                break;
            case 'D':
                playerPosition[0]++;
                break;
            case 'L':
                playerPosition[1]--;
                break;
            case 'R':
                playerPosition[1]++;
                break;
            default:
                break;
        }
        room[playerPosition[0]][playerPosition[1]] = 'S';
    }

    private static void CheckPlayerPosition(int[] playerPosition, int[] enemyPosition)
    {
        if (playerPosition[1] < enemyPosition[1] && room[enemyPosition[0]][enemyPosition[1]] == 'd'
                                                             && enemyPosition[0] == playerPosition[0])
        {
            room[playerPosition[0]][playerPosition[1]] = 'X';
            Console.WriteLine($"Sam died at {playerPosition[0]}, {playerPosition[1]}");
            PrintRoom();
        }
        else if (enemyPosition[1] < playerPosition[1] && room[enemyPosition[0]][enemyPosition[1]] == 'b' && enemyPosition[0] == playerPosition[0])
        {
            room[playerPosition[0]][playerPosition[1]] = 'X';
            Console.WriteLine($"Sam died at {playerPosition[0]}, {playerPosition[1]}");

            PrintRoom();
        }
    }

    private static void PrintRoom()
    {
        foreach (var cell in room)
        {
            Console.WriteLine(string.Join("", cell));
        }

        Environment.Exit(0);
    }

    private static void GetEnemyPossition(int[] playerPosition, int[] enemyPosition)
    {
        for (int j = 0; j < room[playerPosition[0]].Length; j++)
        {
            if (room[playerPosition[0]][j] != '.' && room[playerPosition[0]][j] != 'S')
            {
                enemyPosition[0] = playerPosition[0];
                enemyPosition[1] = j;
            }
        }
    }

    private static void MoveEnemyD(int row, int col)
    {
        if (row >= 0 && row < room.Length && col - 1 >= 0 && col - 1 < room[row].Length)
        {
            room[row][col] = '.';
            room[row][col - 1] = 'd';
        }
        else
        {
            room[row][col] = 'b';
        }
    }

    private static void MoveEnemyB(int row, int col)
    {
        if (row >= 0 && row < room.Length && col + 1 >= 0 && col + 1 < room[row].Length)
        {
            room[row][col] = '.';
            room[row][col + 1] = 'b';
        }
        else
        {
            room[row][col] = 'd';
        }
    }

    private static void FindPlayerPosition(int[] playerPosition)
    {
        for (int row = 0; row < room.Length; row++)
        {
            for (int col = 0; col < room[row].Length; col++)
            {
                if (room[row][col] == 'S')
                {
                    playerPosition[0] = row;
                    playerPosition[1] = col;
                }
            }
        }
    }

    private static void FillRoom()
    {
        int n = int.Parse(Console.ReadLine());
        room = new char[n][];

        for (int row = 0; row < n; row++)
        {
            room[row] = Console.ReadLine().ToCharArray();
        }
    }
}
