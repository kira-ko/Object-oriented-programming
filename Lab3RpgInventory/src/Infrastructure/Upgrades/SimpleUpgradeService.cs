using RpgInventory.Domain.Entities;
using RpgInventory.Domain.Interfaces;
using RpgInventory.Domain.Results;
using RpgInventory.Infrastructure.Builders;

namespace RpgInventory.Infrastructure.Upgrades;

public sealed class SimpleUpgradeService : IUpgradeService
{
    private readonly WeaponBuilder _weaponBuilder = new();
    private readonly ArmorBuilder _armorBuilder = new();

    public ActionResult Upgrade(Item item, int level)
    {
        if (item is null) throw new ArgumentNullException(nameof(item));
        if (level < 1) return ActionResult.Fail("Upgrade level must be >= 1.");

        // Нельзя улучшать использованное/исчезнувшее
        if (item.State.Name == "Consumed")
            return ActionResult.Fail("Consumed item cannot be upgraded.");

        if (item is Weapon weapon)
        {
            _weaponBuilder.Reset(weapon);
            _weaponBuilder.ApplyUpgradeLevel(level);
            var upgraded = _weaponBuilder.Build();

            return ActionResult.Ok($"Weapon upgraded to damage {upgraded.Damage}.");
        }

        if (item is Armor armor)
        {
            _armorBuilder.Reset(armor);
            _armorBuilder.ApplyUpgradeLevel(level);
            var upgraded = _armorBuilder.Build();

            return ActionResult.Ok($"Armor upgraded to defense {upgraded.Defense}.");
        }

        return ActionResult.Fail("This item type cannot be upgraded.");
    }

    public ActionResult Combine(Item first, Item second)
    {
        if (first is null) throw new ArgumentNullException(nameof(first));
        if (second is null) throw new ArgumentNullException(nameof(second));

        if (first.GetType() != second.GetType())
            return ActionResult.Fail("Only items of the same type can be combined.");

        if (first is Weapon w1 && second is Weapon w2)
        {
            // складываем урон и чуть уменьшаем вес (как будто переплавили)
            var combined = new Weapon($"{w1.Name}+{w2.Name}", (w1.Weight + w2.Weight) * 0.9, w1.Damage + w2.Damage);
            return ActionResult.Ok($"Combined weapon created: damage {combined.Damage}.");
        }

        if (first is Armor a1 && second is Armor a2)
        {
            var combined = new Armor($"{a1.Name}+{a2.Name}", (a1.Weight + a2.Weight) * 0.9, a1.Defense + a2.Defense);
            return ActionResult.Ok($"Combined armor created: defense {combined.Defense}.");
        }

        return ActionResult.Fail("This item type cannot be combined.");
    }
}
