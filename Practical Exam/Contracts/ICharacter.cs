using DungeonsAndCodeWizards.Models.Bags;
using DungeonsAndCodeWizards.Models.Characters;
using DungeonsAndCodeWizards.Models.Items;

namespace DungeonsAndCodeWizards.Contracts
{
    public interface ICharacter
    {
        double BaseHealth { get; }
        double BaseArmor { get; }
        double AbilityPoints { get; }
        Bag Bag { get; }
        Faction Faction { get; }
        bool IsAlive { get; set; }
        double RestHealMultiplier { get; }

        void TakeDamage(double hitPoints);

        void Rest();

        void UseItem(Item item);

        void UseItemOn(Item item, Character character);

        void GiveCharacterItem(Item item, Character character);

        void ReceiveItem(Item item);
    }
}
