using System.Collections.Generic;
using DungeonsAndCodeWizards.Models.Items;

namespace DungeonsAndCodeWizards.Contracts
{
    public interface IBag
    {
        int Capacity { get; }
        double Load { get; }

        void AddItem(Item item);

        Item GetItem(string name);
    }
}
