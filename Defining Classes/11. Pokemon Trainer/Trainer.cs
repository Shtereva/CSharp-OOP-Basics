using System.Collections.Generic;
public class Trainer
{
    private string name;
    private int numberOfBadges;
    private List<Pokemon> pokemons;

    public Trainer(string name)
    {
        this.name = name;
        this.numberOfBadges = 0;
        this.pokemons = new List<Pokemon>();
    }

    public string Name => this.name;

    public int NumberOfBadges
    {
        get => this.numberOfBadges;
        set { this.numberOfBadges = value; }
    }

    public List<Pokemon> Pokemons
    {
        get => this.pokemons;
        set { this.pokemons = value; }
    }

    public override string ToString()
    {
        return $"{this.name} {this.numberOfBadges} {this.pokemons.Count}";
    }
}
