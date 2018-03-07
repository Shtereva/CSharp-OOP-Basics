using System.Collections.Generic;
using GrandPrix.Models;

namespace GrandPrix.Factory
{
    public static class TyreFactory
    {
        public static Tyre GetTyre(List<string> commandArgs)
        {
            if (commandArgs[4] == "Hard")
            {
                return new HardTyre(double.Parse(commandArgs[5]));
            }

            return new UltrasoftTyre(double.Parse(commandArgs[5]), double.Parse(commandArgs[6]));
        }
    }
}
