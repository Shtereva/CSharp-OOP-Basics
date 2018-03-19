using System;
using DungeonsAndCodeWizards.Contracts;
using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Models.Items
{
    public class HealthPotion : Item
    {
        public HealthPotion() : base(5)
        {
        }

        public override void AffectCharacter(Character character)
        {
            this.IsCharachterAlive(character);
            character.IncreaseHealth(20);
        }

        private void IsCharachterAlive(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }
    }
}
