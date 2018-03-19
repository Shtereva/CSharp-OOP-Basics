using System;
using DungeonsAndCodeWizards.Models.Items;

namespace DungeonsAndCodeWizards.Factories
{
    public class ItemFactory
    {
        public Item CreateItem(string name)
        {
            if (name == "ArmorRepairKit")
            {
                return new ArmorRepairKit();
            }

            if (name == "HealthPotion")
            {
                return new HealthPotion();
            }

            if (name == "PoisonPotion")
            {
                return new PoisonPotion();
            }

            throw new ArgumentException($"Invalid item \"{name}\"!");
        }
    }
}
