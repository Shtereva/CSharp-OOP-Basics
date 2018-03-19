using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonsAndCodeWizards.Factories;
using DungeonsAndCodeWizards.Models.Characters;
using DungeonsAndCodeWizards.Models.Items;

namespace DungeonsAndCodeWizards
{
    public class DungeonMaster
    {
        private ICollection<Character> party;
        private Stack<Item> pool;
        private int survivorRounds;

        public DungeonMaster()
        {
            this.party = new List<Character>();
            this.pool = new Stack<Item>();
        }
        public string JoinParty(string[] args)
        {
            string characterType = args[1];
            string name = args[2];

            var factory = new CharacterFactory();
            var character = factory.CreateCharacter(args[0], characterType, name);
            this.party.Add(character);

            return $"{name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];

            var factory = new ItemFactory();
            var item = factory.CreateItem(itemName);
            this.pool.Push(item);

            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];
            this.CharacterExist(characterName);

            if (!this.pool.Any())
            {
                throw new InvalidOperationException("No items left in pool!");
            }

            var item = this.pool.Pop();
            this.party.First(c => c.Name == characterName).ReceiveItem(item);

            return $"{characterName} picked up {item.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            this.CharacterExist(characterName);

            var item = this.party.First(c => c.Name == characterName).Bag.GetItem(itemName);
            this.party.First(c => c.Name == characterName).UseItem(item);

            return $"{this.party.First(c => c.Name == characterName).Name} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            this.CharacterExist(giverName);
            this.CharacterExist(receiverName);

            var item = this.party.First(c => c.Name == giverName).Bag.GetItem(itemName);

            this.party.First(c => c.Name == giverName)
                .UseItemOn(item, this.party.First(c => c.Name == receiverName));

            return $"{giverName} used {itemName} on {receiverName}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            this.CharacterExist(giverName);
            this.CharacterExist(receiverName);

            var item = this.party.First(c => c.Name == giverName).Bag.GetItem(itemName);

            this.party.First(c => c.Name == giverName)
                .GiveCharacterItem(item, this.party.First(c => c.Name == receiverName));

            return $"{giverName} gave {receiverName} {itemName}.";
        }

        public string GetStats()
        {
            var characters = this.party
                .OrderByDescending(c => c.IsAlive)
                .ThenByDescending(c => c.Health);

            return string.Join(Environment.NewLine, characters);
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            this.CharacterExist(attackerName);
            this.CharacterExist(receiverName);

            if (this.party.First(c => c.Name == attackerName).GetType().Name != "Warrior")
            {
                throw new ArgumentException($"{attackerName} cannot attack!");
            }

            var attacker = (Warrior)this.party.First(c => c.Name == attackerName);
            var target = this.party.First(c => c.Name == receiverName);

            attacker.Attack(target);

            var sb = new StringBuilder();
            sb.AppendLine(
                $"{attacker.Name} attacks {target.Name} for {attacker.AbilityPoints} hit points! {target.Name} has {target.Health}/{target.BaseHealth} HP and {target.Armor}/{target.BaseArmor} AP left!");

            if (!target.IsAlive)
            {
                sb.AppendLine($"{target.Name} is dead!");
            }

            return sb.ToString().Trim();
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];

            this.CharacterExist(healerName);
            this.CharacterExist(healingReceiverName);

            if (this.party.First(c => c.Name == healerName).GetType().Name != "Cleric")
            {
                throw new ArgumentException($"{healerName} cannot heal!");
            }

            var healer = (Cleric)this.party.First(c => c.Name == healerName);
            var toBeHealed = this.party.First(c => c.Name == healingReceiverName);

            healer.Heal(toBeHealed);

            return
                $"{healer.Name} heals {toBeHealed.Name} for {healer.AbilityPoints}! {toBeHealed.Name} has {toBeHealed.Health} health now!";
        }

        public string EndTurn(string[] args)
        {
            var outputLines = new List<string>();
            var survivors = this.party.Where(c => c.IsAlive).ToList();

            foreach (var character in survivors)
            {
                var healthBeforeRest = character.Health;
                character.Rest();
                outputLines.Add($"{character.Name} rests ({healthBeforeRest} => {character.Health})");
            }

            if (survivors.Count == 0 || survivors.Count == 1)
            {
                this.survivorRounds++;
            }

            return string.Join(Environment.NewLine, outputLines);
        }

        public bool IsGameOver()
        {
            if (this.survivorRounds > 1)
            {
                return true;
            }

            return false;
        }

        private void CharacterExist(string characterName)
        {
            if (this.party.All(p => p.Name != characterName))
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }
        }
    }
}
