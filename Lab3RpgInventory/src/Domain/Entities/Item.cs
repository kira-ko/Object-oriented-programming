using RpgInventory.Domain.Interfaces;
using RpgInventory.Domain.States;


namespace RpgInventory.Domain.Entities;

/// Базовый предмет.
/// Абстракция: общие данные + состояние предмета (State).
public abstract class Item
{
    public Guid Id { get; }
    public string Name { get; }
    public double Weight { get; }

    public IItemState State { get; private set; }

    protected Item(string name, double weight)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Item name cannot be empty.", nameof(name));
        if (weight < 0)
            throw new ArgumentOutOfRangeException(nameof(weight), "Weight cannot be negative.");

        Id = Guid.NewGuid();
        Name = name;
        Weight = weight;

        State = new InInventoryState(); // по умолчанию предмет "в инвентаре"
    }

    public void MarkUsed() => State = State.OnUsed();
    public void MarkEquipped() => State = State.OnEquipped();
    public void MarkConsumed() => State = new ConsumedState();

    public void MarkUnequipped() => State = State.OnUnequipped();

    public override string ToString() => $"{Name} (weight: {Weight}, state: {State.Name})";
}
