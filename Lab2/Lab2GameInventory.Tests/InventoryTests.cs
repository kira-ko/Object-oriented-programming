using Lab2GameInventory.Inventory;
using Lab2GameInventory.Items.Armor;
using Lab2GameInventory.Items.Potion;
using Lab2GameInventory.Items.Quest;
using Lab2GameInventory.Items.Weapon;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab2GameInventory.Tests
{
    [TestClass]
    public class InventoryTests
    {
        [TestMethod]
        public void AddItem_ReturnsTrue_WhenThereIsSpace()
        {
            Inventory inventory = new Inventory(2);
            Weapon sword = new Weapon("w1", "Sword", 10, WeaponType.Sword);
            bool added = inventory.AddItem(sword);
            Assert.IsTrue(added);
            Assert.AreEqual(1, inventory.GetAllItems().Count);
        }

        [TestMethod]
        public void AddItem_ReturnsFalse_WhenInventoryIsFull()
        {
            Inventory inventory = new Inventory(1);
            Weapon sword = new Weapon("w1", "Sword", 10, WeaponType.Sword);
            Armor helmet = new Armor("a1", "Helmet", 3, ArmorType.Helmet);
            bool addedFirst = inventory.AddItem(sword);
            bool addedSecond = inventory.AddItem(helmet);
            Assert.IsTrue(addedFirst);
            Assert.IsFalse(addedSecond);
            Assert.AreEqual(1, inventory.GetAllItems().Count);
        }

        [TestMethod]
        public void RemoveItemById_ReturnsTrue_WhenItemExists()
        {
            Inventory inventory = new Inventory(5);
            QuestItem letter = new QuestItem("q1", "Old Letter", "Find the Truth", QuestItemType.Document);
            inventory.AddItem(letter);
            bool removed = inventory.RemoveItemById("q1");
            Assert.IsTrue(removed);
            Assert.AreEqual(0, inventory.GetAllItems().Count);
        }

        [TestMethod]
        public void UseItem_RemovesPotion_FromInventory()
        {
            Inventory inventory = new Inventory(5);
            Potion potion = new Potion("p1", "Health Potion", 20, PotionType.Health);
            inventory.AddItem(potion);
            bool used = inventory.UseItem("p1");
            Assert.IsTrue(used);
            Assert.AreEqual(0, inventory.GetAllItems().Count);
        }

        [TestMethod]
        public void UpgradeItem_IncreasesWeaponLevel_AndDamage()
        {
            Inventory inventory = new Inventory(5);
            Weapon sword = new Weapon("w1", "Sword", 10, WeaponType.Sword);
            inventory.AddItem(sword);

            int damageBefore = sword.Damage;
            int levelBefore = sword.Level;

            bool upgraded = inventory.UpgradeItem("w1");

            Assert.IsTrue(upgraded);
            Assert.AreEqual(levelBefore + 1, sword.Level);
            Assert.IsTrue(sword.Damage > damageBefore);
        }

        [TestMethod]
        public void UpgradeItem_ReturnsFalse_ForQuestItem()
        {
            Inventory inventory = new Inventory(5);
            QuestItem letter = new QuestItem("q1", "Old Letter", "Find the Truth", QuestItemType.Document);
            inventory.AddItem(letter);
            bool upgraded = inventory.UpgradeItem("q1");
            Assert.IsFalse(upgraded);
        }
    }
}
