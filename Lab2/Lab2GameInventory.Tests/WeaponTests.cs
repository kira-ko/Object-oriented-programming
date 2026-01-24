using System;
using Lab2GameInventory.Items.Weapon;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab2GameInventory.Tests
{
    [TestClass]
    public class WeaponTests
    {
        [TestMethod]
        public void Weapon_IsCreated_WithCorrectDamage()
        {

            Weapon weapon = new Weapon("w1", "Sword", 10, WeaponType.Sword);
            int damage = weapon.Damage;
            Assert.AreEqual(10, damage);
        }

        [TestMethod]
        public void Weapon_Equip_SetsIsEquippedToTrue()
        {
 
            Weapon weapon = new Weapon("w1", "Sword", 10, WeaponType.Sword);
            weapon.Equip();
            Assert.IsTrue(weapon.IsEquipped);
        }

        [TestMethod]
        public void Weapon_Throws_WhenDamageIsZero()
        {

            try
            {
                Weapon weapon = new Weapon("w1", "Sword", 0, WeaponType.Sword);
                Assert.Fail();
            }
            catch (ArgumentException)
            {
                Assert.IsTrue(true);
            }
        }
    }
}
