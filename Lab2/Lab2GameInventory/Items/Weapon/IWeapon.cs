using Lab2GameInventory.Items.Common;

namespace Lab2GameInventory.Items.Weapon
{
    public interface IWeapon : IItem, IEquipable, IUpgradable
    {
        int Damage { get; }
        WeaponType Type { get; }
    }
}
