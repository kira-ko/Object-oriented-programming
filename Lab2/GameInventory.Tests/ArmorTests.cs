using GameInventory.Items;
using Xunit;

namespace GameInventory.Tests
{
    public class ArmorTests
    {
        [Fact]
        public void Armor_ShouldStoreDefense()
        {
            // Arrange
            var armor = new Armor("a1", "Helmet", 1, 5);

            // Act
            int defense = armor.Defense;

            // Assert
            Assert.Equal(5, defense);
        }

        [Fact]
        public void GetInfo_ShouldContainArmorData()
        {
            // Arrange
            var armor = new Armor("a1", "Helmet", 1, 5);

            // Act
            string info = armor.GetInfo();

            // Assert
            Assert.Contains("Armor", info);
            Assert.Contains("Helmet", info);
            Assert.Contains("Level: 1", info);
            Assert.Contains("Defense: 5", info);
        }
    }
}
