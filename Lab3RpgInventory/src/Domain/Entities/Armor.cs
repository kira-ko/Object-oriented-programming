using RpgInventory.Domain.Enums;
using RpgInventory.Domain.Interfaces;

namespace RpgInventory.Domain.Entities;

public sealed class Armor : Item, IEquipable
{
    public int Defense { get; }
    public EquipmentSlot Slot => EquipmentSlot.Body;

    public Armor(string name, double weight, int defense)
        : base(name, weight)
    {
        if (defense <= 0)
            throw new ArgumentOutOfRangeException(nameof(defense), "Defense must be positive.");

        Defense = defense;
    }

    public override string ToString() => $"{base.ToString()}, def: {Defense}";
}
