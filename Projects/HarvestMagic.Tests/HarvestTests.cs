using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HarvestMagic.Tests
{
    public class HarvestTests
    {
        [TestClass]
        public class Constructor
        {
            [TestMethod]
            public void ShouldThrow_ArgumentNullException_When_account_IsNull()
            {
                Assert.Inconclusive("todo");
            }

            [TestMethod]
            public void ShouldThrow_ValidationException_When_account_IsNotValid()
            {
                Assert.Inconclusive("todo");
            }
        }
    }
}
