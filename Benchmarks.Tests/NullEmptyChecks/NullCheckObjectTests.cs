using Benchmarks.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Benchmarks.Tests.NullEmptyChecks
{
    [TestClass]
    public class NullCheckObjectTests
    {
        private User user;

        [TestMethod]
        public void EqualOperator_Success()
        {
            user = null;
            if (user == null)
            {
                user = new User();
            }
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void IsOperator_Success()
        {
            user = null;
            if (user is null)
            {
                user = new User();
            }
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void Default_Success()
        {
            user = null;
            if (user == default)
            {
                user = new User();
            }
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void Equals_Success()
        {
            user = null;
            if (Equals(user, null))
            {
                user = new User();
            }
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void ReferenceEquals_Success()
        {
            user = null;
            if (ReferenceEquals(user, null))
            {
                user = new User();
            }
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void Coalesce_Success()
        {
            user = null;
            user = user ?? new User();
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void Ternary_Success()
        {
            user = null;
            user = user == null ? new User() : user;
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void IsNotEmptyBraces_Success()
        {
            user = null;
            if (user is not { })
            {
                user = new User();
            }
            Assert.IsNotNull(user);
        }
    }
}
