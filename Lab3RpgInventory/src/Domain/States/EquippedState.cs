using RpgInventory.Domain.Interfaces;

namespace RpgInventory.Domain.States;

public sealed class EquippedState : IItemState
{
    public string Name => "Equipped";

    public bool CanUse => true;     // например, оружие можно "использовать" как экипировку
    public bool CanEquip => false;  // уже экипировано

    public IItemState OnUsed() => this;
    public IItemState OnEquipped() => this;
    public IItemState OnUnequipped() => new InInventoryState();
}
