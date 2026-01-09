using RpgInventory.Domain.Entities;
using RpgInventory.Domain.Interfaces;

namespace RpgInventory.Infrastructure.Factories;

public sealed class CommonItemFactory : IItemFactory
{
    public Weapon CreateWeapon(string name, double weight, int baseDamage)
        => new(name, weight, baseDamage);

    public Armor CreateArmor(string name, double weight, int baseDefense)
        => new(name, weight, baseDefense);

    public Potion CreatePotion(string name, double weight, string effect, int charges)
        => new(name, weight, effect, charges);

    public QuestItem CreateQuestItem(string name, double weight, string questKey)
        => new(name, weight, questKey);
}
