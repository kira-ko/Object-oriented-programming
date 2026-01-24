namespace Lab2GameInventory.Items.Common
{
    public interface IItem
    {
        string Id { get; }
        string Name { get; }

        string GetInfo();
    }
}
