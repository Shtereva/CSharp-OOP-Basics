using System.Collections.Generic;
using GrandPrix.Models;

namespace GrandPrix.Factory
{
    public static class DriverFactory
    {
        public static Driver GetDriver(List<string> commandArgs)
        {
            Tyre tyre = TyreFactory.GetTyre(commandArgs);

            Car car = new Car(int.Parse(commandArgs[2]), double.Parse(commandArgs[3]), tyre);

            if (commandArgs[0] == "Aggressive")
            {
                return new AggressiveDriver(commandArgs[1], car);
            }

            return new EnduranceDriver(commandArgs[1], car);
        }
    }
}
