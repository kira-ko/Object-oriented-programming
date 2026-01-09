using RpgInventory.Domain.Enums;
using RpgInventory.Domain.Interfaces;
using RpgInventory.Domain.Results;

namespace RpgInventory.Domain.Entities;

public sealed class Equipment
{
    private readonly Dictionary<EquipmentSlot, Item> _equipped = new();

    public Item? GetItem(EquipmentSlot slot)
        => _equipped.TryGetValue(slot, out var item) ? item : null;

    public EquipResult Equip(Item item)
    {
        if (item is null) throw new ArgumentNullException(nameof(item));

        if (item is not IEquipable equipable)
            return EquipResult.Fail("This item cannot be equipped.");

        if (!item.State.CanEquip)
            return EquipResult.Fail($"Item cannot be equipped in state '{item.State.Name}'.");

        _equipped[equipable.Slot] = item;
        item.MarkEquipped();

        return EquipResult.Ok($"Equipped '{item.Name}' to slot {equipable.Slot}.");
    }

    public EquipResult Unequip(EquipmentSlot slot)
    {
        if (!_equipped.TryGetValue(slot, out var item))
            return EquipResult.Fail($"Slot {slot} is empty.");

        _equipped.Remove(slot);
        item.MarkUnequipped();

        return EquipResult.Ok($"Unequipped slot {slot}.");
    }

    public IReadOnlyDictionary<EquipmentSlot, Item> Snapshot()
        => new Dictionary<EquipmentSlot, Item>(_equipped);
}
