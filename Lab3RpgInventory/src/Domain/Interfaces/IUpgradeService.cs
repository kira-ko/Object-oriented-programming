using RpgInventory.Domain.Entities;
using RpgInventory.Domain.Results;

namespace RpgInventory.Domain.Interfaces;

/// Контракт для улучшения/комбинирования предметов.
/// Application зависит от интерфейса (DIP).
public interface IUpgradeService
{
    ActionResult Upgrade(Item item, int level);
    ActionResult Combine(Item first, Item second);
}
