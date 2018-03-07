using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GrandPrix.Factory;
using GrandPrix.Models;

namespace GrandPrix
{
    public class RaceTower
    {
        private List<Driver> drivers;
        private int completedLaps;
        private int totalLaps;
        private int trackLength;
        private WeatherType weather;
        private List<FailedDriver> failedDrivers;
        public int CompletedLaps => this.completedLaps;

        public RaceTower()
        {
            this.drivers = new List<Driver>();
            this.weather = WeatherType.Sunny;
            this.failedDrivers = new List<FailedDriver>();
        }

        public void SetTrackInfo(int lapsNumber, int trackLen)
        {
            this.totalLaps = lapsNumber;
            this.trackLength = trackLen;
        }
        public void RegisterDriver(List<string> commandArgs)
        {
            Driver driver = DriverFactory.GetDriver(commandArgs);

            this.drivers.Add(driver);
        }

        public void DriverBoxes(List<string> commandArgs)
        {
            this.drivers.Find(d => d.Name == commandArgs[1]).TotalTime += 20;

            if (commandArgs[0] == "Refuel")
            {
                this.drivers.Find(d => d.Name == commandArgs[1]).Refuel(double.Parse(commandArgs[2]));
            }
            else
            {
                Tyre tyre = commandArgs[2] == "Hard" ? (Tyre)new HardTyre(double.Parse(commandArgs[3]))
                    : new UltrasoftTyre(double.Parse(commandArgs[3]), double.Parse(commandArgs[4]));

                this.drivers.Find(d => d.Name == commandArgs[1]).Car.ChangeTyre(tyre);
            }
        }

        public string CompleteLaps(List<string> commandArgs)
        {
            if (int.Parse(commandArgs[0]) > this.totalLaps - this.completedLaps)
            {
                throw new ArgumentException($"There is no time! On lap {this.completedLaps}.");
            }

            for (int i = 0; i < int.Parse(commandArgs[0]); i++)
            {
                this.IncreaseDriversTotalTime();
                this.ReduceDriversFuel();
                this.RemoveUnfinishedDrivers();

                this.completedLaps++;
                this.CheckForOvertakingOpportunities();
            }

            var winner = this.drivers.OrderBy(d => d.TotalTime).First();
            return $"{winner.Name} wins the race for {winner.TotalTime:f3} seconds.";
        }

        private void RemoveUnfinishedDrivers()
        {
            foreach (var failedDriver in this.failedDrivers)
            {
                if (this.drivers.Any(d => d.Name == failedDriver.Driver.Name))
                {
                    this.drivers.Remove(failedDriver.Driver);
                }
            }
        }

        private void ReduceDriversFuel()
        {
            foreach (var driver in this.drivers)
            {
                try
                {
                    driver.ReduceFuelAmount(this.trackLength);
                }
                catch (Exception e)
                {
                    this.failedDrivers.Add(new FailedDriver(driver, e.Message));
                }
            }
        }

        private void IncreaseDriversTotalTime()
        {
            foreach (var driver in this.drivers)
            {
                double formula = (60 / (this.trackLength / driver.Speed));
                driver.TotalTime += formula;
            }
        }

        private void CheckForOvertakingOpportunities()
        {
            var overtakings = new Queue<Driver>(this.drivers.OrderByDescending(d => d.TotalTime));

            while (overtakings.Count > 1)
            {
                var driver = overtakings.Dequeue();
                try
                {
                    bool isSuccess = false;
                    driver.Overtake(overtakings, this.weather, ref isSuccess);

                    if (isSuccess)
                    {
                        Console.WriteLine($"{driver.Name} has overtaken {overtakings.Peek().Name} on lap {this.completedLaps}.");
                    }
                }
                catch (Exception e)
                {
                    this.failedDrivers.Add(new FailedDriver(driver, e.Message));

                }
            }

            this.RemoveUnfinishedDrivers();
        }

        public string GetLeaderboard()
        {
            var sb = new StringBuilder();

            int possition = 0;
            sb.AppendLine($"Lap {this.completedLaps}/{this.totalLaps}");
            foreach (var driver in this.drivers.OrderBy(d => d.TotalTime))
            {
                sb.AppendLine($"{++possition} {driver.Name} {driver.TotalTime:f3}");
            }

            var failed = this.failedDrivers;
            failed.Reverse();

            foreach (var failedDriver in failed)
            {
                sb.AppendLine($"{++possition} {failedDriver.Driver.Name} {failedDriver.Message}");
            }

            return sb.ToString().Trim();
        }

        public void ChangeWeather(List<string> commandArgs)
        {
            this.weather = Enum.Parse<WeatherType>(commandArgs[0]);
        }

    }
}
