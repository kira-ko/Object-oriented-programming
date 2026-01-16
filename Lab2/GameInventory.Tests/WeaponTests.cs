using GameInventory.Items;
using Xunit;

namespace GameInventory.Tests
{
    public class WeaponTests
    {
        [Fact]
        public void Weapon_ShouldStoreDamage()
        {
            // Arrange
            var weapon = new Weapon("w1", "Sword", 1, 10);

            // Act
            int damage = weapon.Damage;

            // Assert
            Assert.Equal(10, damage);
        }

        [Fact]
        public void GetInfo_ShouldContainWeaponData()
        {
            // Arrange
            var weapon = new Weapon("w1", "Sword", 1, 10);

            // Act
            string info = weapon.GetInfo();

            // Assert
            Assert.Contains("Weapon", info);
            Assert.Contains("Sword", info);
            Assert.Contains("Level: 1", info);
            Assert.Contains("Damage: 10", info);
        }
    }
}
