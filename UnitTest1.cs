using BNG;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace YakTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_GetYakMilk()
        {
            YakInfo yak = new YakInfo();
            int age = 4;
            int days = 13;
            decimal expected = (decimal)491.6600;
            decimal yakMilk = yak.GetYakMilk(age, days);
            Assert.AreEqual(expected, yakMilk);
        }

        [TestMethod]
        public void Test_GetYakWool()
        {
            YakInfo yak = new YakInfo();
            int age = 4;
            int days = 20;
            int expected = 2;
            int yakWool = yak.GetYakWool(age, days);
            Assert.AreEqual(expected, yakWool);
        }
    }
}
