using System;
public class DateModifier
{
    private int diff;

    public int Diff
    {
        get => this.diff;
        set { this.diff = value; }
    }

    public void GetDiiffInDays(string dateOne, string dateTwo)
    {
        var firstDate = DateTime.Parse(dateOne);
        var secondDate = DateTime.Parse(dateTwo);
        var difference = firstDate.Date.Subtract(secondDate);
        this.Diff = Math.Abs(difference.Days);
    }
}
