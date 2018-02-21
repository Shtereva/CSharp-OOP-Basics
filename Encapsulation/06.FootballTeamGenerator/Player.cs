using System;
using System.Collections.Generic;
using System.Linq;

public class Player
{
    private string name;
    private Stats stats;

    public Player(Stats stats, string name)
    {
        this.stats = stats;
        Name = name;
    }

    public string Name
    {
        get => this.name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }

            this.name = value;
        }
    }
    public double SkillLevel => CalculateSkillLevel();


    private double CalculateSkillLevel()
    {
        var stats = new List<double>()
        {
            this.stats.Endurance,
            this.stats.Sprint,
            this.stats.Dribble,
            this.stats.Passing,
            this.stats.Shooting
        };

        return stats.Average();
    }
}
