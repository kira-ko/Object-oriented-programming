using RpgInventory.Domain.Entities;
using RpgInventory.Infrastructure.Upgrades;
using Xunit;

namespace Lab3RpgInventory_tests.Upgrade;

public sealed class UpgradeServiceTests
{
    [Fact]
    public void Upgrade_Weapon_Level2_ReturnsSuccess()
    {
        var service = new SimpleUpgradeService();
        var weapon = new Weapon("Sword", 2.0, 10);

        var result = service.Upgrade(weapon, level: 2);

        Assert.True(result.Success);
        Assert.Contains("Weapon upgraded", result.Message);
    }

    [Fact]
    public void Upgrade_ConsumedItem_ReturnsFail()
    {
        var service = new SimpleUpgradeService();
        var potion = new Potion("Heal", 0.5, "Heal", charges: 1);

        potion.ConsumeOneCharge();
        potion.MarkConsumed();

        var result = service.Upgrade(potion, level: 1);

        Assert.False(result.Success);
    }

    [Fact]
    public void Combine_TwoWeapons_ReturnsSuccess()
    {
        var service = new SimpleUpgradeService();
        var w1 = new Weapon("A", 2.0, 10);
        var w2 = new Weapon("B", 3.0, 5);

        var result = service.Combine(w1, w2);

        Assert.True(result.Success);
        Assert.Contains("Combined weapon", result.Message);
    }

    [Fact]
    public void Combine_DifferentTypes_ReturnsFail()
    {
        var service = new SimpleUpgradeService();
        var w = new Weapon("Sword", 2.0, 10);
        var a = new Armor("Armor", 5.0, 7);

        var result = service.Combine(w, a);

        Assert.False(result.Success);
    }
}
