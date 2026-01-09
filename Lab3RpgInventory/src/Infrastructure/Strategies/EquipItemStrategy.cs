using RpgInventory.Domain.Entities;
using RpgInventory.Domain.Interfaces;
using RpgInventory.Domain.Results;

namespace RpgInventory.Infrastructure.Strategies;

public sealed class EquipItemStrategy : IUseStrategy
{
    public UseResult Use(Item item, UseContext context)
    {
        if (!item.State.CanUse)
            return UseResult.Fail($"Item cannot be used in state '{item.State.Name}'.");

        var equipResult = context.Equipment.Equip(item);
        return equipResult.Success
            ? UseResult.Ok(equipResult.Message)
            : UseResult.Fail(equipResult.Message);
    }
}
