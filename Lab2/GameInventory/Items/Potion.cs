namespace GameInventory.Items
{
    public class Potion : ItemBase
    {
        public int HealAmount { get; }

        public Potion(string id, string name, int level, int healAmount)
            : base(id, name, level)
        {
            HealAmount = healAmount;
        }

        public override string GetInfo()
        {
            return $"Potion: {Name}, Level: {Level}, Heal: {HealAmount}";
        }
    }
}
