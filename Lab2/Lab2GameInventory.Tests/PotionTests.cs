using System;
using Lab2GameInventory.Items.Potion;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab2GameInventory.Tests
{
    [TestClass]
    public class PotionTests
    {
        [TestMethod]
        public void Potion_IsCreated_WithCorrectPower()
        {
            Potion potion = new Potion("p1", "Health Potion", 20, PotionType.Health);
            int power = potion.Power;
            Assert.AreEqual(20, power);
        }

        [TestMethod]
        public void Potion_GetInfo_ContainsPower()
        {
            Potion potion = new Potion("p1", "Health Potion", 15, PotionType.Health);
            string info = potion.GetInfo();
            Assert.IsTrue(info.Contains("Power"));
            Assert.IsTrue(info.Contains("15"));
        }

        [TestMethod]
        public void Potion_Throws_WhenPowerIsZero()
        {
            try
            {
                Potion potion = new Potion("p1", "Bad Potion", 0, PotionType.Health);
                Assert.Fail();
            }
            catch (ArgumentException)
            {
                Assert.IsTrue(true);
            }
        }
    }
}
