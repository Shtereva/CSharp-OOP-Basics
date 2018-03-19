using System;
using DungeonsAndCodeWizards.Contracts;
using DungeonsAndCodeWizards.Models.Bags;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public class Cleric : Character, IHealable
    {
        public override double RestHealMultiplier => 0.5;

        public Cleric(string name,Faction faction) 
            : base(name, 50, 25, 40, new Backpack(), faction)
        {
        }

        public void Heal(Character character)
        {
            this.IsCharachterAlive();
            this.IsEnemyCharachterAlive(character);

            if (character.Faction != this.Faction)
            {
                throw new InvalidOperationException("Cannot heal enemy character!");
            }

            character.IncreaseHealth(this.AbilityPoints);
        }

        private void IsCharachterAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }

        private void IsEnemyCharachterAlive(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }
    }
}
