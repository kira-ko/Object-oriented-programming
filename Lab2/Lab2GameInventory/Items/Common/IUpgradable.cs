namespace Lab2GameInventory.Items.Common
{
    public interface IUpgradable
    {
        int Level { get; }

        void Upgrade();
    }
}
