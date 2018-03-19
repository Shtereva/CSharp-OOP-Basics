using DungeonsAndCodeWizards.Contracts;
using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Models.Items
{
    public abstract class Item : IItem
    {
        public int Weight { get; protected set; }

        protected Item(int weight)
        {
            this.Weight = weight;
        }

        public abstract void AffectCharacter(Character character);
    }
}
