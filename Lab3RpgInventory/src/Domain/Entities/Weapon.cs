using RpgInventory.Domain.Enums;
using RpgInventory.Domain.Interfaces;

namespace RpgInventory.Domain.Entities;

public sealed class Weapon : Item, IEquipable
{
    public int Damage { get; }
    public EquipmentSlot Slot => EquipmentSlot.Weapon;

    public Weapon(string name, double weight, int damage)
        : base(name, weight)
    {
        if (damage <= 0)
            throw new ArgumentOutOfRangeException(nameof(damage), "Damage must be positive.");

        Damage = damage;
    }

    public override string ToString() => $"{base.ToString()}, dmg: {Damage}";
}
