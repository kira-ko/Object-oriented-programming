using GameInventory.Items;
using Xunit;

namespace GameInventory.Tests
{
    public class QuestItemTests
    {
        [Fact] 
        public void QuestItem_ShouldStoreQuestId() 
        {
            // Arrange
            var item = new QuestItem("q1", "Ancient Key", 1, "quest_123"); 

            // Act 
            string questId = item.QuestId; 

            // Assert
            Assert.Equal("quest_123", questId); 
        }

        [Fact] // Второй тест
        public void GetInfo_ShouldContainQuestItemData() 
        {
            // Arrange
            var item = new QuestItem("q1", "Ancient Key", 1, "quest_123"); 

            // Act
            string info = item.GetInfo();

            // Assert
            Assert.Contains("QuestItem", info); 
            Assert.Contains("Ancient Key", info); 
            Assert.Contains("Level: 1", info); 
            Assert.Contains("QuestId: quest_123", info);
        }
    }
}
