using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Benchmarks.Strings
{
    [RankColumn]
    [MemoryDiagnoser]
    public class ConcatenateBenchmark
    {
        [Params(10, 100, 1000)]
        public int size;

        IEnumerable<int> numbers;
        List<int> numbersList;

        [GlobalSetup]
        public void Setup()
        {
            numbers = Enumerable.Range(0, size);
            numbersList = numbers.ToList();
        }

        [Benchmark]
        public string StringPlusOperator()
        {
            string str = string.Empty;
            for (int i = 0; i < size; i++)
            {
                str += i;
            }
            return str;
        }

        [Benchmark]
        public string StringBuilder_Append()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < size; i++)
            {
                stringBuilder.Append(i);
            }
            return stringBuilder.ToString();
        }

        [Benchmark]
        public string StringBuilder_AppendWithSize()
        {
            StringBuilder stringBuilder = new StringBuilder(size);
            for (int i = 0; i < size; i++)
            {
                stringBuilder.Append(i);
            }
            return stringBuilder.ToString();
        }

        [Benchmark]
        public string StringBuilder_AppendJoin()
        {
            StringBuilder stringBuilder = new StringBuilder();
            return stringBuilder.AppendJoin(null, numbers).ToString();
        }

        [Benchmark]
        public string StringJoin()
        {
            return string.Join(null, numbers);
        }

        [Benchmark]
        public string StringJoin_List()
        {
            return string.Join(null, numbersList);
        }

        [Benchmark]
        public string StringConcat()
        {
            return string.Concat(numbers);
        }

        [Benchmark]
        public string StringConcat_List()
        {
            return string.Concat(numbersList);
        }
    }
}
