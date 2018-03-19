using System;
using DungeonsAndCodeWizards.Contracts;
using DungeonsAndCodeWizards.Models.Bags;
using DungeonsAndCodeWizards.Models.Items;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public abstract class Character : ICharacter
    {
        public double BaseHealth { get; }
        public double BaseArmor { get; }
        public double AbilityPoints { get; }
        public Bag Bag { get; }
        public Faction Faction { get; }
        public bool IsAlive { get; set; }
        public virtual double RestHealMultiplier => 0.2;

        private string name;
        private double health;
        private double armor;

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                this.name = value;
            }
        }

        public double Health
        {
            get => this.health;
            private set
            {
                if (value <= 0)
                {
                    this.IsAlive = false;
                    this.health = 0;
                    return;
                }
                this.health = Math.Min(value, this.BaseHealth);
            }
        }

        public double Armor
        {
            get => this.armor;
            private set
            {
                if (value <= 0)
                {
                    this.armor = 0;
                    return;
                }
                this.armor = Math.Min(value, this.BaseArmor);
            }
        }

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
            this.Name = name;
            this.BaseHealth = health;
            this.BaseArmor = armor;
            this.IsAlive = true;
            this.Health = health;
            this.Armor = armor;
        }

        public virtual void TakeDamage(double hitPoints)
        {
            this.IsCharachterAlive();

            double diff = Math.Abs(this.Armor - hitPoints);
            this.Armor -= hitPoints;

            if (this.Armor <= 0)
            {
                this.Health -= diff;
            }
        }

        public virtual void Rest()
        {
            this.IsCharachterAlive();
            this.Health += (this.BaseHealth * this.RestHealMultiplier);
        }

        public virtual void UseItem(Item item)
        {
            this.IsCharachterAlive();
            item.AffectCharacter(this);
        }

        public virtual void UseItemOn(Item item, Character character)
        {
            this.IsCharachterAlive();
            this.IsEnemyCharachterAlive(character);
            item.AffectCharacter(character);
        }

        public virtual void GiveCharacterItem(Item item, Character character)
        {
            this.IsCharachterAlive();
            this.IsEnemyCharachterAlive(character);
            character.Bag.AddItem(item);
        }

        public virtual void ReceiveItem(Item item)
        {
            this.IsCharachterAlive();
            this.Bag.AddItem(item);
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

        public void IncreaseHealth(double amount)
        {
            this.Health += amount;
        }

        public void DecreaseHealth(double amount)
        {
            this.Health -= amount;
        }

        public void ResetArmor()
        {
            this.Armor = this.BaseArmor;
        }

        public override string ToString()
        {
            string status = this.IsAlive ? "Alive" : "Dead";
            return $"{this.Name} - HP: {this.Health}/{this.BaseHealth}, AP: {this.Armor}/{this.BaseArmor}, Status: {status}";
        }
    }
}
