using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PokerTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int x = 0;
            x = 5;
            Assert.IsTrue(x < 5, "Testmethod1 has failed");
        }
    }
}
