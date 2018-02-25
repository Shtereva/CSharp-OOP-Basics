using System;
public class StartUp
{
    public static void Main()
    {
        string input;

        while ((input = Console.ReadLine()) != "End")
        {
            var citizenInfo = input.Split();

            var citizen = new Citizen(citizenInfo[0], citizenInfo[1], citizenInfo[2]);

            IPerson person = (IPerson) citizen;
            Console.WriteLine(person.GetName());

            IResident resident = (IResident) citizen;
            Console.WriteLine(resident.GetName());
        }
    }
}
