using System;

public class Ferrari : ICar
{
    private string model = "488-Spider";
    private string driver;

    public Ferrari(string driver)
    {
        this.driver = driver;
    }

    public string UseBrakes()
    {
        return "Brakes!";
    }

    public string Gas()
    {
       return "Zadu6avam sA!";
    }

    public override string ToString()
    {
        return $"{this.model}/{this.UseBrakes()}/{this.Gas()}/{this.driver}";
    }
}
