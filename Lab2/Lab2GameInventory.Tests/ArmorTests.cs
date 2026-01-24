using System;
using Lab2GameInventory.Items.Armor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab2GameInventory.Tests
{
    [TestClass]
    public class ArmorTests
    {
        [TestMethod]
        public void Armor_IsCreated_WithCorrectDefense()
        {
            Armor armor = new Armor("a1", "Shield", 7, ArmorType.Shield);
            int defense = armor.Defense;
            Assert.AreEqual(7, defense);
        }

        [TestMethod]
        public void Armor_Equip_SetsIsEquippedToTrue()
        {
            Armor armor = new Armor("a1", "Helmet", 5, ArmorType.Helmet);
            armor.Equip();
            Assert.IsTrue(armor.IsEquipped);
        }

        [TestMethod]
        public void Armor_Upgrade_IncreasesLevel_AndDefense()
        {
            Armor armor = new Armor("a1", "Chestplate", 10, ArmorType.Chestplate);
            armor.Upgrade();
            Assert.AreEqual(2, armor.Level);
            Assert.AreEqual(13, armor.Defense);
        }

        [TestMethod]
        public void Armor_Throws_WhenDefenseIsZero()
        {
            try
            {
                Armor armor = new Armor("a1", "BadArmor", 0, ArmorType.Boots);
                Assert.Fail();
            }
            catch (ArgumentException)
            {
                Assert.IsTrue(true);
            }
        }
    }
}
