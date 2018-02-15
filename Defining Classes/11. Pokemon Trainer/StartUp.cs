using System;
using System.Collections.Generic;
using System.Linq;
public class StartUp
{
    public static void Main()
    {
        var trainers = new List<Trainer>();
        string input = String.Empty;

        while ((input = Console.ReadLine()) != "Tournament")
        {
            var args = input.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            string trainerName = args[0];
            string pokemonName = args[1];
            string pokemonElement = args[2];
            int pokemonHealth = int.Parse(args[3]);

            var pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

            if (trainers.Any(t => t.Name == trainerName))
            {
                trainers.Find(t => t.Name == trainerName).Pokemons.Add(pokemon);
            }

            else
            {
                trainers.Add(new Trainer(trainerName) { Pokemons = { pokemon } });
            }
        }

        while ((input = Console.ReadLine()) != "End")
        {
            foreach (var trainer in trainers)
            {
                if (trainer.Pokemons.Any(p => p.Element == input))
                {
                    trainer.NumberOfBadges++;
                }

                else
                {
                    foreach (var trainerPokemon in trainer.Pokemons)
                    {
                        trainerPokemon.Health -= 10;
                    }

                    trainer.Pokemons = trainer.Pokemons.Where(p => p.Health > 0).ToList();
                }
            }
        }

        trainers
            .OrderByDescending(t => t.NumberOfBadges)
            .ToList()
            .ForEach(Console.WriteLine);
    }
}
