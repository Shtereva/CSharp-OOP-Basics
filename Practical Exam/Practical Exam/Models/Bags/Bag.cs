using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DungeonsAndCodeWizards.Contracts;
using DungeonsAndCodeWizards.Models.Items;

namespace DungeonsAndCodeWizards.Models.Bags
{
    public abstract class Bag : IBag
    {
        public int Capacity { get; protected set; }
        public double Load => this.Items.Sum(i => i.Weight);
        private ICollection<Item> items;

        public IReadOnlyCollection<Item> Items => this.items.ToList().AsReadOnly();


        protected Bag(int capacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (!this.Items.Any())
            {
                throw new InvalidOperationException("Bag is empty!");
            }

            if (this.Items.All(i => i.GetType().Name != name))
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }

            var item = this.items.First(i => i.GetType().Name == name);
            this.items.Remove(item);

            return item;
        }
    }
}
