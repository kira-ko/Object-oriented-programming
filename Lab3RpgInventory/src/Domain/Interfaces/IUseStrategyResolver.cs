using RpgInventory.Domain.Entities;

namespace RpgInventory.Domain.Interfaces;

public interface IUseStrategyResolver
{
    IUseStrategy Resolve(Item item);
}
