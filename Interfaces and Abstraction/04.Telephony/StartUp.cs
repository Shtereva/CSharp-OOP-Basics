using System;
public class StartUp
{
    public static void Main()
    {
        var phoneNumbers = Console.ReadLine().Split();
        var urlList = Console.ReadLine().Split();

        var smartPhone = new SmartPhone();

        foreach (var number in phoneNumbers)
        {
            try
            {
                smartPhone.Cal(number);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        foreach (var url in urlList)
        {
            try
            {
                smartPhone.Browse(url);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
