using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Benchmarks.Tests.NullEmptyChecks
{
    [TestClass]
    public class NullCheckStringTests
    {
        private readonly string message = "null value";

        [TestMethod]
        public void EqualOperator_Success()
        {
            string str = null;
            if (str == null)
            {
                str = message;
            }
            Assert.AreEqual(str, message);
        }

        [TestMethod]
        public void IsOperator_Success()
        {
            string str = null;
            if (str is null)
            {
                str = message;
            }
            Assert.AreEqual(str, message);
        }

        [TestMethod]
        public void Default_Success()
        {
            string str = null;
            if (str == default)
            {
                str = message;
            }
            Assert.AreEqual(str, message);
        }

        [TestMethod]
        public void Equals_Success()
        {
            string str = null;
            if (string.Equals(str, null))
            {
                str = message;
            }
            Assert.AreEqual(str, message);
        }

        [TestMethod]
        public void ReferenceEquals_Success()
        {
            string str = null;
            if (ReferenceEquals(null, str))
            {
                str = message;
            }
            Assert.AreEqual(str, message);
        }

        [TestMethod]
        public void IsNullOrEmpty_Success()
        {
            string str = null;
            if (string.IsNullOrEmpty(str))
            {
                str = message;
            }
            Assert.AreEqual(str, message);
        }

        [TestMethod]
        public void Coalesce_Success()
        {
            string str = null;
            str = str ?? message;
            Assert.AreEqual(str, message);
        }

        [TestMethod]
        public void Ternary_Success()
        {
            string str = null;
            str = str == null ? message : str;
            Assert.AreEqual(str, message);
        }

        [TestMethod]
        public void IsNotEmptyBraces_Success()
        {
            string str = null;
            if (str is not { })
            {
                str = message;
            }
            Assert.AreEqual(str, message);
        }
    }
}
