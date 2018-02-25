using System;
using System.Linq;

public class SmartPhone : ICallable, IBrowsable
{
    public void Cal(string phoneNumber)
    {

        if (phoneNumber.Any(c => !char.IsDigit(c)))
        {
            throw new ArgumentException("Invalid number!");
        }

        Console.WriteLine($"Calling... {phoneNumber}");
    }

    public void Browse(string url)
    {
        if (url.Any(char.IsDigit))
        {
            throw new ArgumentException("Invalid URL!");
        }

        Console.WriteLine($"Browsing: {url}!");
    }
}
