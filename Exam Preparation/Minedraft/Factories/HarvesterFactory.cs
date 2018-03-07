using System;
using System.Collections.Generic;

public static class HarvesterFactory
{
    public static Harvester Create(List<string> arguments)
    {
        try
        {
            string type = arguments[0];
            string id = arguments[1];
            double oreOutput = double.Parse(arguments[2]);
            double energyRequirement = double.Parse(arguments[3]);

            if (type == "Sonic")
            {
                int sonicFactor = int.Parse(arguments[4]);

                return new SonicHarvester(id, oreOutput, energyRequirement, sonicFactor);
            }

            return new HammerHarvester(id, oreOutput, energyRequirement);
        }
        catch (ArgumentException e)
        {
            throw new ArgumentException($"Harvester is not registered, because of it's {e.Message}");
        }
    }
}
