namespace RpgInventory.Domain.Entities;

/// Контекст использования предмета.
/// Содержит объекты, с которыми может взаимодействовать стратегия.
public sealed class UseContext
{
    public Inventory Inventory { get; }
    public Equipment Equipment { get; }

    public UseContext(Inventory inventory, Equipment equipment)
    {
        Inventory = inventory ?? throw new ArgumentNullException(nameof(inventory));
        Equipment = equipment ?? throw new ArgumentNullException(nameof(equipment));
    }
}
