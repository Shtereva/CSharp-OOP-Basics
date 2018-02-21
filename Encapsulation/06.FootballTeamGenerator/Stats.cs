using System;

public class Stats
{
    private double endurance;
    private double sprint;
    private double dribble;
    private double passing;
    private double shooting;

    public Stats(double endurance, double sprint, double dribble, double passing, double shooting)
    {
        Endurance = endurance;
        Sprint = sprint;
        Dribble = dribble;
        Passing = passing;
        Shooting = shooting;
    }

    public double Endurance
    {
        get => this.endurance;
        private set { ValidateStat(value, nameof(this.Endurance)); this.endurance = value; }
    }

    public double Sprint
    {
        get => this.sprint;
        private set { ValidateStat(value, nameof(this.Sprint)); this.sprint = value; }
    }

    public double Dribble
    {
        get => this.dribble;
        private set { ValidateStat(value, nameof(this.Dribble)); this.dribble = value; }
    }

    public double Passing
    {
        get => this.passing;
        private set { ValidateStat(value, nameof(this.Passing)); this.passing = value; }
    }

    public double Shooting
    {
        get => this.shooting;
        private set { ValidateStat(value, nameof(this.Shooting)); this.shooting = value; }
    }

    private void ValidateStat(double stat, string statName)
    {
        if (stat < 0 || stat > 100)
        {
            throw new ArgumentException($"{statName} should be between 0 and 100.");
        }
    }
}
