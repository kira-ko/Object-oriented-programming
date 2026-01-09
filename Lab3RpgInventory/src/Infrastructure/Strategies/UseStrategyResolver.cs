using RpgInventory.Domain.Entities;
using RpgInventory.Domain.Interfaces;

namespace RpgInventory.Infrastructure.Strategies;

public sealed class UseStrategyResolver : IUseStrategyResolver
{
    private readonly IUseStrategy _equipStrategy = new EquipItemStrategy();
    private readonly IUseStrategy _potionStrategy = new ConsumePotionStrategy();
    private readonly IUseStrategy _questStrategy = new QuestItemUseStrategy();

    public IUseStrategy Resolve(Item item)
    {
        if (item is Potion) return _potionStrategy;
        if (item is QuestItem) return _questStrategy;

        // Weapon и Armor — экипируем
        if (item is IEquipable) return _equipStrategy;

        // если появятся предметы другого типа
        return _questStrategy;
    }
}
