using System;
using System.Collections.Generic;
    public class StartUp
    {
        public static void Main()
        {
            int carsToTrack = int.Parse(Console.ReadLine());
            var cars = new Dictionary<string, Car>();
            AddCars(carsToTrack, cars);

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                var args = input.Split();

                string carModel = args[1];
                double amountOfKm = double.Parse(args[2]);

                cars[carModel].Dive(amountOfKm);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.Value);
            }
        }

        private static void AddCars(int carsToTrack, Dictionary<string, Car> cars)
        {
            for (int i = 0; i < carsToTrack; i++)
            {
                var carInfo = Console.ReadLine().Split();

                if (!cars.ContainsKey(carInfo[0]))
                {
                    cars[carInfo[0]] = new Car(carInfo[0], double.Parse(carInfo[1]), double.Parse(carInfo[2]));
                }
            }
        }
    }
