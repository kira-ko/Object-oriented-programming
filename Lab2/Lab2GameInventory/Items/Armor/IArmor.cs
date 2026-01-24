using Lab2GameInventory.Items.Common;

namespace Lab2GameInventory.Items.Armor
{
    public interface IArmor : IItem, IEquipable, IUpgradable
    {
        int Defense { get; }
        ArmorType Type { get; }
    }
}
