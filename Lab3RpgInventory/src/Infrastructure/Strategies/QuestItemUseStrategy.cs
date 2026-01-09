using RpgInventory.Domain.Entities;
using RpgInventory.Domain.Interfaces;
using RpgInventory.Domain.Results;

namespace RpgInventory.Infrastructure.Strategies;

public sealed class QuestItemUseStrategy : IUseStrategy
{
    public UseResult Use(Item item, UseContext context)
    {
        return UseResult.Fail("Quest items cannot be used directly.");
    }
}
