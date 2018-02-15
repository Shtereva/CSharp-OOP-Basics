using System;
using System.Collections.Generic;
public class Person
{
    private string name;
    private Company company;
    private Car car;
    private List<Pokemon> pokemons;
    private List<Parent> parents;
    private List<Children> children;

    public Person(string name)
    {
        this.name = name;
        this.pokemons = new List<Pokemon>();
        this.parents = new List<Parent>();
        this.children = new List<Children>();
    }

    public Person(string name, Company company) : this(name)
    {
        this.company = company;
    }

    public Person(string name, Car car) : this(name)
    {
        this.car = car;
    }

    public string Name => this.name;

    public Company Company
    {
        get => this.company;
        set { this.company = value; }
    }

    public Car Car
    {
        get => this.car;
        set { this.car = value; }
    }

    public List<Pokemon> Pokemons => this.pokemons;
    public List<Parent> Parents => this.parents;
    public List<Children> Children => this.children;

    public override string ToString()
    {
        string nl = Environment.NewLine;
        string printPokemons = this.pokemons.Count == 0
            ? $"Pokemon:{string.Join(nl, this.pokemons)}{nl}"
            : $"Pokemon:{nl}{string.Join(nl, this.pokemons)}{nl}";

        string printParents = this.parents.Count == 0
            ? $"Parents:{string.Join(nl, parents)}{nl}"
            : $"Parents:{nl}{string.Join(nl, parents)}{nl}";

        string printChildren = this.children.Count == 0
            ? $"Children:{string.Join(nl, children)}"
            : $"Children:{nl}{string.Join(nl, children)}";

        return $"{this.name}{nl}Company:{this.company}{nl}" +
               $"Car:{this.car}{nl}" +
               $"{printPokemons}" +
               $"{printParents}" +
               $"{printChildren}";
    }
}
