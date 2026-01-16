namespace GameInventory.Items
{
    public abstract class ItemBase : IItem
    {
        public string Id { get; }
        public string Name { get; }
        public int Level { get; }

        protected ItemBase(string id, string name, int level)
        {
            Id = id;
            Name = name;
            Level = level;
        }

        public abstract string GetInfo();
    }
}

// SRP