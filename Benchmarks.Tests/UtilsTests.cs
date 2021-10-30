using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Benchmarks.Tests
{
    [TestClass]
    public class UtilsTests
    {
        [TestMethod]
        public void GenerateRandomUserList_Success()
        {
            var list = Utils.GenerateRandomUserList(10);
            Assert.AreEqual(10, list.Count());
        }

        [TestMethod]
        public void GenerateRandomNumbersList_Success()
        {
            var list = Utils.GenerateRandomNumbersList(10);
            Assert.AreEqual(10, list.Count());
        }

        [TestMethod]
        public void GenerateRandomStringList_Success()
        {
            var list = Utils.GenerateRandomStringList(10);
            Assert.AreEqual(10, list.Count());
        }

        [TestMethod]
        public void GenerateRandomStringListWithNull_Success()
        {
            var list = Utils.GenerateRandomStringListWithNull(10);
            Assert.AreEqual(10, list.Count());
            Assert.AreEqual(5, list.Where(x => x == null).Count());
            Assert.AreEqual(5, list.Where(x => x != null).Count());
        }
    }
}
