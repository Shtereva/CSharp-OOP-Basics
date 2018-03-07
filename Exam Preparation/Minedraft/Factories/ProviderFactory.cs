using System;
using System.Collections.Generic;

public static class ProviderFactory
{
    public static Provider Create(List<string> arguments)
    {
        try
        {
            string type = arguments[0];
            string id = arguments[1];
            double energyOutput = double.Parse(arguments[2]);

            if (type == "Solar")
            {
               return new SolarProvider(id, energyOutput);
            }

            return new PressureProvider(id, energyOutput);
        }
        catch (ArgumentException e)
        {
            throw new ArgumentException($"Provider is not registered, because of it's {e.Message}");
        }
    }
}
