using RpgInventory.Domain.Entities;
using RpgInventory.Domain.Interfaces;
using RpgInventory.Domain.Results;

namespace RpgInventory.Application.Services;

/// Сценарий "использовать предмет".
/// SRP: отвечает только за use-case использования.
/// DIP: зависит от абстракций (IUseStrategyResolver), а не от конкретных стратегий.

public sealed class ItemUseService
{
    private readonly IUseStrategyResolver _resolver;

    public ItemUseService(IUseStrategyResolver resolver)
    {
        _resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
    }

    public UseResult Use(Item item, UseContext context)
    {
        if (item is null) throw new ArgumentNullException(nameof(item));
        if (context is null) throw new ArgumentNullException(nameof(context));

        if (!item.State.CanUse)
            return UseResult.Fail($"Item cannot be used in state '{item.State.Name}'.");

        var strategy = _resolver.Resolve(item);
        return strategy.Use(item, context);
    }
}
