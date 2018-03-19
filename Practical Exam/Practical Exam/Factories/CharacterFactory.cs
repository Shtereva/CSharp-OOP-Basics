using System;
using System.Collections.Generic;
using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Factories
{
    public class CharacterFactory
    {
        public Character CreateCharacter(string factions, string type, string name)
        {
            Faction faction;
            try
            {
                faction = Enum.Parse<Faction>(factions);
            }
            catch (ArgumentException)
            {
                throw new ArgumentException($"Invalid faction \"{factions}\"!");
            }

            if (type == "Warrior")
            {
                return new Warrior(name, faction);
            }

            if (type == "Cleric")
            {
                return new Cleric(name, faction);
            }
            
            throw new ArgumentException($"Invalid character type \"{type}\"!");
        }
    }
}
