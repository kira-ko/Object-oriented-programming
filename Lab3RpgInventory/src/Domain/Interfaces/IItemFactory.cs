using RpgInventory.Domain.Entities;

namespace RpgInventory.Domain.Interfaces;

/// Abstract Factory: создаёт семейство предметов (оружие/броня/зелье/квестовый).
/// Application будет зависеть от этого интерфейса (DIP).
public interface IItemFactory
{
    Weapon CreateWeapon(string name, double weight, int baseDamage);
    Armor CreateArmor(string name, double weight, int baseDefense);
    Potion CreatePotion(string name, double weight, string effect, int charges);
    QuestItem CreateQuestItem(string name, double weight, string questKey);
}
