using GameInventory.Items;
using Xunit;

namespace GameInventory.Tests
{
    public class PotionTests
    {
        [Fact]
        public void Potion_ShouldStoreHealAmount()
        {
            // Arrange
            var potion = new Potion("p1", "Healing Potion", 1, 20);

            // Act
            int heal = potion.HealAmount;

            // Assert
            Assert.Equal(20, heal);
        }

        [Fact]
        public void GetInfo_ShouldContainPotionData()
        {
            // Arrange
            var potion = new Potion("p1", "Healing Potion", 1, 20);

            // Act
            string info = potion.GetInfo();

            // Assert
            Assert.Contains("Potion", info);
            Assert.Contains("Healing Potion", info);
            Assert.Contains("Level: 1", info);
            Assert.Contains("Heal: 20", info);
        }
    }
}
