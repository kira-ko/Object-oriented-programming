using RpgInventory.Infrastructure.Factories;
using Xunit;

namespace Lab3RpgInventory_tests.Factories;

public sealed class ItemFactoryTests
{
    [Fact]
    public void CommonFactory_CreatesWeaponWithBaseDamage()
    {
        var factory = new CommonItemFactory();
        var weapon = factory.CreateWeapon("Sword", 2.0, 10);

        Assert.Equal(10, weapon.Damage);
        Assert.Contains("Sword", weapon.Name);
    }

    [Fact]
    public void RareFactory_AddsBonusToWeaponDamage()
    {
        var factory = new RareItemFactory();
        var weapon = factory.CreateWeapon("Sword", 2.0, 10);

        Assert.True(weapon.Damage > 10);
        Assert.Contains("Rare", weapon.Name);
    }
}
