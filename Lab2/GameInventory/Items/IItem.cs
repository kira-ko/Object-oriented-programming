namespace GameInventory.Items
{
    public interface IItem
    {
        string Id { get; }
        string Name { get; }
        int Level { get; }

        string GetInfo();
    }
}

// DIP 