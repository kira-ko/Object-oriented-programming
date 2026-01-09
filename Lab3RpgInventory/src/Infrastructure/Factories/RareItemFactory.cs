using RpgInventory.Domain.Entities;
using RpgInventory.Domain.Interfaces;

namespace RpgInventory.Infrastructure.Factories;

public sealed class RareItemFactory : IItemFactory
{
    private const int WeaponBonus = 3;
    private const int ArmorBonus = 2;

    public Weapon CreateWeapon(string name, double weight, int baseDamage)
        => new($"{name} (Rare)", weight, baseDamage + WeaponBonus);

    public Armor CreateArmor(string name, double weight, int baseDefense)
        => new($"{name} (Rare)", weight, baseDefense + ArmorBonus);

    public Potion CreatePotion(string name, double weight, string effect, int charges)
        => new($"{name} (Rare)", weight, effect, charges);

    public QuestItem CreateQuestItem(string name, double weight, string questKey)
        => new($"{name} (Rare)", weight, questKey);
}
