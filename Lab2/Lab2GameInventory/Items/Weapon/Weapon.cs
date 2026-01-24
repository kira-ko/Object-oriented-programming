using System;
using Lab2GameInventory.Items.Common;

namespace Lab2GameInventory.Items.Weapon
{
    public class Weapon : IWeapon
    {
        public string Id { get; }
        public string Name { get; }

        public int Damage { get; private set; }
        public WeaponType Type { get; }

        public bool IsEquipped { get; private set; }

        public int Level { get; private set; }

        public Weapon(string id, string name, int damage, WeaponType type)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }

            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            if (damage <= 0)
            {
                throw new ArgumentException("Damage must be greater than zero.");
            }

            Id = id;
            Name = name;
            Damage = damage;
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
            Damage = Damage + 5;
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

            return "Weapon: " + Name +
                   " | Type: " + Type +
                   " | Damage: " + Damage +
                   " | Level: " + Level +
                   " | " + equippedText;
        }
    }
}

