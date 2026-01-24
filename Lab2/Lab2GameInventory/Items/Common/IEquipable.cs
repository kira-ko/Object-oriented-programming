namespace Lab2GameInventory.Items.Common
{
    public interface IEquipable
    {
        bool IsEquipped { get; }

        void Equip();
        void Unequip();
    }
}
