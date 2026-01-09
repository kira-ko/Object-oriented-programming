using RpgInventory.Domain.Entities;
using RpgInventory.Domain.Interfaces;
using RpgInventory.Domain.Results;

namespace RpgInventory.Infrastructure.Strategies;

public sealed class ConsumePotionStrategy : IUseStrategy
{
    public UseResult Use(Item item, UseContext context)
    {
        if (!item.State.CanUse)
            return UseResult.Fail($"Item cannot be used in state '{item.State.Name}'.");

        if (item is not Potion potion)
            return UseResult.Fail("This strategy works only for potions.");

        if (!potion.HasCharges)
        {
            // если у зелья нет зарядов — оно считается использованным полностью
            item.MarkUsed();
            return UseResult.Fail("Potion has no charges.");
        }

        potion.ConsumeOneCharge();

        if (!potion.HasCharges)
        {
            item.MarkConsumed();
            return UseResult.Ok("Potion used. No charges left (consumed).");
        }

        return UseResult.Ok($"Potion used. Charges left: {potion.Charges}");

    }
}
