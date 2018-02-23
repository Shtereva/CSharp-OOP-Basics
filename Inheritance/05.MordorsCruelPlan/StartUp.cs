using System;

public class StartUp
{
    public static void Main()
    {
        var input = Console.ReadLine().Split();

        var food = new Food();
        var mood = new Mood();
        Console.WriteLine(mood.GetMood(food.GetFood(input)));
    }
}
