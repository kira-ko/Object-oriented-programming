using RpgInventory.Domain.Interfaces;

namespace RpgInventory.Domain.States;

public sealed class InInventoryState : IItemState
{
    public string Name => "InInventory";

    public bool CanUse => true;
    public bool CanEquip => true;

    public IItemState OnUsed() => this;
    public IItemState OnEquipped() => new EquippedState();
    public IItemState OnUnequipped() => this;
}
