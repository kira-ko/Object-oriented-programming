using RpgInventory.Domain.Entities;
using RpgInventory.Domain.Interfaces;
using RpgInventory.Domain.Results;

namespace RpgInventory.Application.Services;

public sealed class ItemUpgradeService
{
    private readonly IUpgradeService _upgradeService;

    public ItemUpgradeService(IUpgradeService upgradeService)
    {
        _upgradeService = upgradeService ?? throw new ArgumentNullException(nameof(upgradeService));
    }

    public ActionResult Upgrade(Item item, int level)
        => _upgradeService.Upgrade(item, level);

    public ActionResult Combine(Item first, Item second)
        => _upgradeService.Combine(first, second);
}
