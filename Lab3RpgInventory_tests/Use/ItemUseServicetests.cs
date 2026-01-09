using RpgInventory.Application.Services;
using RpgInventory.Domain.Entities;
using RpgInventory.Domain.Enums;
using RpgInventory.Infrastructure.Strategies;
using Xunit;

namespace Lab3RpgInventory_tests.Use;

public sealed class ItemUseServiceTests
{
    private static (ItemUseService service, UseContext context) Create()
    {
        var inventory = new Inventory();
        var equipment = new RpgInventory.Domain.Entities.Equipment();
        var context = new UseContext(inventory, equipment);

        var resolver = new UseStrategyResolver();
        var service = new ItemUseService(resolver);

        return (service, context);
    }

    [Fact]
    public void Use_Weapon_EquipsAndStateBecomesEquipped()
    {
        var (service, context) = Create();
        var weapon = new Weapon("Sword", 2.0, 10);

        Assert.Equal("InInventory", weapon.State.Name);

        var result = service.Use(weapon, context);

        Assert.True(result.Success);
        Assert.Equal("Equipped", weapon.State.Name);

        var equipped = context.Equipment.GetItem(EquipmentSlot.Weapon);
        Assert.NotNull(equipped);
        Assert.Equal(weapon.Id, equipped!.Id);
    }

    [Fact]
    public void Use_Weapon_WhenAlreadyEquipped_ReturnsFail()
    {
        var (service, context) = Create();
        var weapon = new Weapon("Sword", 2.0, 10);

        var first = service.Use(weapon, context);
        Assert.True(first.Success);
        Assert.Equal("Equipped", weapon.State.Name);

        var second = service.Use(weapon, context);

        Assert.False(second.Success);
    }

    [Fact]
    public void Use_Potion_DecreasesCharges()
    {
        var (service, context) = Create();
        var potion = new Potion("Healing", 0.5, "Heal", charges: 2);

        var result = service.Use(potion, context);

        Assert.True(result.Success);
        Assert.Equal(1, potion.Charges);
        Assert.Equal("InInventory", potion.State.Name);
    }

    [Fact]
    public void Use_Potion_WhenChargesBecomeZero_StateBecomesConsumed()
    {
        var (service, context) = Create();
        var potion = new Potion("Healing", 0.5, "Heal", charges: 1);

        var result = service.Use(potion, context);

        Assert.True(result.Success);
        Assert.Equal(0, potion.Charges);
        Assert.Equal("Consumed", potion.State.Name);
    }

    [Fact]
    public void Use_QuestItem_ReturnsFail()
    {
        var (service, context) = Create();
        var quest = new QuestItem("Key", 0.2, "QUEST_1");

        var result = service.Use(quest, context);

        Assert.False(result.Success);
    }
}
