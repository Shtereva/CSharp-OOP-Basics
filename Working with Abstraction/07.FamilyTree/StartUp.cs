using System;
public class StartUp
{
    public static void Main(string[] args)
    {
        var familyTreeBuilder = new FamilyTreeBuilder(Console.ReadLine());

        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            familyTreeBuilder.ParseInput(command);
        }

        Console.Write(familyTreeBuilder);
    }
}
