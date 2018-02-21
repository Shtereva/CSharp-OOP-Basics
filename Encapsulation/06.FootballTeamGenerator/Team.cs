using System;
using System.Collections.Generic;
using System.Linq;

public class Team
{
    private string name;
    private List<Player> players;

    public Team(string name)
    {
        this.Name = name;
        this.players = new List<Player>();
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

    public double Rating()
    {
        return Math.Round(players.Any() ? this.players.Average(p => p.SkillLevel) : 0, 0);

    }

    public void AddPlayer(Player player)
    {
        this.players.Add(player);
    }

    public void RemovePlayer(string playerName)
    {
        if (this.players.All(p => p.Name != playerName))
        {
            throw new ArgumentException($"Player {playerName} is not in {this.name} team.");
        }
        this.players.RemoveAll(p => p.Name == playerName);
    }
}
