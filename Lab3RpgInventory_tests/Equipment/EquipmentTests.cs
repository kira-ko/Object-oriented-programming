using RpgInventory.Domain.Entities;
using RpgInventory.Domain.Enums;
using Xunit;

namespace Lab3RpgInventory_tests.Equipment;

public sealed class EquipmentTests
{
    [Fact]
    public void Equip_Armor_PutsInBodySlot_AndStateBecomesEquipped()
    {
        var equipment = new RpgInventory.Domain.Entities.Equipment();
        var armor = new Armor("Leather", 5.0, 7);

        Assert.Equal("InInventory", armor.State.Name);

        var result = equipment.Equip(armor);

        Assert.True(result.Success);
        Assert.Equal("Equipped", armor.State.Name);
        Assert.NotNull(equipment.GetItem(EquipmentSlot.Body));
    }

    [Fact]
    public void Unequip_EmptySlot_ReturnsFail()
    {
        var equipment = new RpgInventory.Domain.Entities.Equipment();

        var result = equipment.Unequip(EquipmentSlot.Weapon);

        Assert.False(result.Success);
    }

    [Fact]
    public void Unequip_ReturnsItemToInInventoryState()
    {
        var equipment = new RpgInventory.Domain.Entities.Equipment();
        var weapon = new Weapon("Sword", 2.0, 10);

        var equip = equipment.Equip(weapon);
        Assert.True(equip.Success);
        Assert.Equal("Equipped", weapon.State.Name);

        var unequip = equipment.Unequip(EquipmentSlot.Weapon);

        Assert.True(unequip.Success);
        Assert.Equal("InInventory", weapon.State.Name);
        Assert.Null(equipment.GetItem(EquipmentSlot.Weapon));
    }
}
