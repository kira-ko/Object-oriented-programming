 namespace RpgInventory.Domain.Interfaces;

/// Состояние предмета (паттерн State).
/// Ограничивает действия с предметом в зависимости от состояния.
public interface IItemState
{
    string Name { get; }

    bool CanUse { get; }
    bool CanEquip { get; }

    IItemState OnUsed();     // что станет после использования
    IItemState OnEquipped(); // что станет после экипировки
    IItemState OnUnequipped(); // что станет после снятия
}
