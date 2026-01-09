using RpgInventory.Domain.Entities;
using RpgInventory.Domain.Interfaces;

namespace RpgInventory.Infrastructure.Builders;

public sealed class WeaponBuilder : IItemBuilder<Weapon>
{
    private Weapon? _result;

    public void Reset(Weapon baseItem)
    {
        _result = baseItem ?? throw new ArgumentNullException(nameof(baseItem));
    }

    public void ApplyUpgradeLevel(int level)
    {
        if (_result is null) throw new InvalidOperationException("Builder is not initialized.");
        if (level < 1) return;

        // апгрейд: +2 урона за уровень
        var newDamage = _result.Damage + (2 * level);

        _result = new Weapon(_result.Name, _result.Weight, newDamage);
        
        // сохраняем состояние (чтобы апгрейд не снимал предмет)
        if (_result.State.Name == "Consumed") _result.MarkConsumed();
    }

    public Weapon Build()
    {
        if (_result is null) throw new InvalidOperationException("Builder is not initialized.");
        return _result;
    }
}
