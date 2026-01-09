using RpgInventory.Domain.Enums;

namespace RpgInventory.Domain.Interfaces;

/// Интерфейс для предметов, которые можно экипировать.не все предметы обязаны быть экипируемыми. ISP
public interface IEquipable
{
    EquipmentSlot Slot { get; }
}
