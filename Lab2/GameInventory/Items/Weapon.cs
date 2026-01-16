namespace GameInventory.Items
{
    public class Weapon : ItemBase
    {
        public int Damage { get; }

        public Weapon(string id, string name, int level, int damage)
            : base(id, name, level)
        {
            Damage = damage;
        }

        public override string GetInfo()
        {
            return $"Weapon: {Name}, Level: {Level}, Damage: {Damage}";
        }
    }
}
