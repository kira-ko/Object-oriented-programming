using RpgInventory.Domain.Entities;

namespace RpgInventory.Domain.Interfaces;

/// Builder: пошагово "собирает" предмет на основе базового предмета и правил улучшения
public interface IItemBuilder<T> where T : Item
{
    void Reset(T baseItem);
    void ApplyUpgradeLevel(int level);
    T Build();
}
