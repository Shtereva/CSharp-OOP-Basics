using System;
public class StartUp
{
    public static void Main()
    {
        var items = Console.ReadLine().Split();
        int countRemoves = int.Parse(Console.ReadLine());

        var result = new string[5];

        var addCollection = new AddCollection<string>();
        var addRemoveCollection = new AddRemoveCollection<string>();
        var myListCollection = new MyList<string>();

        foreach (var item in items)
        {
            result[0] += addCollection.Add(item) + " ";
            result[1] += addRemoveCollection.Add(item) + " ";
            result[2] += myListCollection.Add(item) + " ";
        }

        for (int i = 0; i < countRemoves; i++)
        {
            result[3] += addRemoveCollection.Remove() + " ";
            result[4] += myListCollection.Remove() + " ";
        }

        Console.WriteLine(string.Join(Environment.NewLine, result));
    }
}
