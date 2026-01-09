using RpgInventory.Domain.Entities;
using RpgInventory.Domain.Results;

namespace RpgInventory.Domain.Interfaces;

/// Strategy: разные алгоритмы использования предметов.
public interface IUseStrategy
{
    UseResult Use(Item item, UseContext context);
}
