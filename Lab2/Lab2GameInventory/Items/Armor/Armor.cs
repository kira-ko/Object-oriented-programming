using System;

namespace Lab2GameInventory.Items.Armor
{
    public class Armor : IArmor
    {
        public string Id { get; }
        public string Name { get; }

        public int Defense { get; private set; }
        public ArmorType Type { get; }

        public bool IsEquipped { get; private set; }

        public int Level { get; private set; }

        public Armor(string id, string name, int defense, ArmorType type)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }

            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            if (defense <= 0)
            {
                throw new ArgumentException("Defense must be greater than zero.");
            }

            Id = id;
            Name = name;
            Defense = defense;
            Type = type;

            IsEquipped = false;
            Level = 1;
        }

        public void Equip()
        {
            IsEquipped = true;
        }

        public void Unequip()
        {
            IsEquipped = false;
        }

        public void Upgrade()
        {
            Level = Level + 1;
            Defense = Defense + 3;
        }

        public string GetInfo()
        {
            string equippedText;

            if (IsEquipped)
            {
                equippedText = "Equipped";
            }
            else
            {
                equippedText = "Not equipped";
            }

            return "Armor: " + Name +
                   " | Type: " + Type +
                   " | Defense: " + Defense +
                   " | Level: " + Level +
                   " | " + equippedText;
        }
    }
}
