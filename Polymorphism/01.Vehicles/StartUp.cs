using System;

public class StartUp
{
    public static void Main()
    {
        var carInfo = Console.ReadLine().Split();
        var truckInfo = Console.ReadLine().Split();
        var busInfo = Console.ReadLine().Split();

        Vehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));
        Vehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));
        Vehicle bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

        int lines = int.Parse(Console.ReadLine());

        for (int i = 0; i < lines; i++)
        {
            var cmdArgs = Console.ReadLine().Split();
            string command = cmdArgs[0];

            try
            {
                ParseCommand(car, truck, bus, cmdArgs, command);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        Console.WriteLine(car);
        Console.WriteLine(truck);
        Console.WriteLine(bus);
    }

    private static void ParseCommand(Vehicle car, Vehicle truck, Vehicle bus, string[] cmdArgs, string command)
    {
        switch (command)
        {
            case "Drive":

                DriveVehicles(car, truck, bus, cmdArgs);
                break;

            case "Refuel":

                RefuelVehicles(car, truck, bus, cmdArgs);
                break;

            default:
                bus.FuelConsumptionPerKm -= 1.4;
                Console.WriteLine(bus.Drive(double.Parse(cmdArgs[2])));
                break;
        }
    }

    private static void RefuelVehicles(Vehicle car, Vehicle truck, Vehicle bus, string[] cmdArgs)
    {
        if (cmdArgs[1] == "Car")
        {
            car.Refuel(double.Parse(cmdArgs[2]));
        }
        else if (cmdArgs[1] == "Truck")
        {
            truck.Refuel(double.Parse(cmdArgs[2]));
        }
        else
        {
            bus.Refuel(double.Parse(cmdArgs[2]));
        }
    }

    private static void DriveVehicles(Vehicle car, Vehicle truck, Vehicle bus, string[] cmdArgs)
    {
        if (cmdArgs[1] == "Car")
        {
            Console.WriteLine(car.Drive(double.Parse(cmdArgs[2])));
        }
        else if (cmdArgs[1] == "Truck")
        {
            Console.WriteLine(truck.Drive(double.Parse(cmdArgs[2])));
        }
        else
        {
            Console.WriteLine(bus.Drive(double.Parse(cmdArgs[2])));
        }
    }
}