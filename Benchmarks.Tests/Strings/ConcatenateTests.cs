using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Benchmarks.Tests.Strings
{
    [TestClass]
    public class ConcatenateTests
    {
        private readonly string expected = "0123456789";
        private int size;
        private IEnumerable<int> numbers;

        public ConcatenateTests()
        {
            size = 10;
            numbers = Enumerable.Range(0, size);
        }

        [TestMethod]
        public void PlusOperator_Success()
        {
            string str = string.Empty;
            for (int i = 0; i < size; i++)
            {
                str += i;
            }
            Assert.AreEqual(expected, str);
        }

        [TestMethod]
        public void StringBuilder_Append_Success()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < size; i++)
            {
                stringBuilder.Append(i);
            }
            Assert.AreEqual(expected, stringBuilder.ToString());
        }

        [TestMethod]
        public void StringBuilder_AppendJoin_Success()
        {
            StringBuilder stringBuilder = new StringBuilder();
            var strAppend = stringBuilder.AppendJoin("", numbers).ToString();
            Assert.AreEqual(expected, strAppend);
        }

        [TestMethod]
        public void String_Join_Success()
        {
            var strJoin = string.Join(null, numbers);
            Assert.AreEqual(expected, strJoin);
        }

        [TestMethod]
        public void String_Concat_Success()
        {
            var strConcat = string.Concat(numbers);
            Assert.AreEqual(expected, strConcat);
        }
    }
}
