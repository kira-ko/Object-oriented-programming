using RpgInventory.Domain.Interfaces;

namespace RpgInventory.Domain.States;

public sealed class ConsumedState : IItemState
{
    public string Name => "Consumed";

    public bool CanUse => false;
    public bool CanEquip => false;

    public IItemState OnUsed() => this;
    public IItemState OnEquipped() => this;
    public IItemState OnUnequipped() => this;
}
