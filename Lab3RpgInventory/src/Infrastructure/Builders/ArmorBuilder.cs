using RpgInventory.Domain.Entities;
using RpgInventory.Domain.Interfaces;

namespace RpgInventory.Infrastructure.Builders;

public sealed class ArmorBuilder : IItemBuilder<Armor>
{
    private Armor? _result;

    public void Reset(Armor baseItem)
    {
        _result = baseItem ?? throw new ArgumentNullException(nameof(baseItem));
    }

    public void ApplyUpgradeLevel(int level)
    {
        if (_result is null) throw new InvalidOperationException("Builder is not initialized.");
        if (level < 1) return;

        var newDefense = _result.Defense + (1 * level);

        _result = new Armor(_result.Name, _result.Weight, newDefense);
    }

    public Armor Build()
    {
        if (_result is null) throw new InvalidOperationException("Builder is not initialized.");
        return _result;
    }
}
