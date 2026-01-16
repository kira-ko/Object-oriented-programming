namespace GameInventory.Items
{
    public class Armor : ItemBase
    {
        public int Defense { get; } // защита

        public Armor(string id, string name, int level, int defense)
            : base(id, name, level)
        {
            Defense = defense;
        }

        public override string GetInfo()
        {
            return $"Armor: {Name}, Level: {Level}, Defense: {Defense}";
        }
    }
}
