using System;

namespace Lab2GameInventory.Items.Potion
{
    public class Potion : IPotion
    {
        public string Id { get; }
        public string Name { get; }

        public int Power { get; }
        public PotionType Type { get; }

        public Potion(string id, string name, int power, PotionType type)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }

            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            if (power <= 0)
            {
                throw new ArgumentException("Power must be greater than zero.");
            }

            Id = id;
            Name = name;
            Power = power;
            Type = type;
        }

        public void Use()
        {
            // Логика применения будет реализована позже
        }

        public string GetInfo()
        {
            return "Potion: " + Name +
                   " | Type: " + Type +
                   " | Power: " + Power;
        }
    }
}
