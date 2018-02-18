using System;

public static class PriceCalculator
{
    public static void CalculateTotalPriseForHoliday(string input)
    {
        var args = input.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

        decimal pricePerDay = decimal.Parse(args[0]);
        int numberOfDays = int.Parse(args[1]);
        var season = Enum.Parse<Season>(args[2]);
        var discountType = args.Length > 3 ? Enum.Parse<DiscountType>(args[3]) : DiscountType.None;

        var aa = Season.Autumn;
        int multiplier = (int)season;
        int discount = (int)discountType;

        decimal totalSum = (pricePerDay * numberOfDays) * multiplier;
        Console.WriteLine($"{totalSum - (totalSum * ((decimal)discount / 100)):f2}");
    }
}
