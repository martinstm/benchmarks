using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace Benchmarks.ForForeachLinq
{
    [ShortRunJob]
    [RankColumn]
    public class IterateSumBenchmark
    {
        private List<int> listInt;
        private IEnumerable<int> listIntEnumerable;

        [Params(10, 100, 1000)]
        public int listSize;

        [GlobalSetup]
        public void Setup()
        {
            listIntEnumerable = Utils.GenerateRandomNumbersList(listSize);
            listInt = listIntEnumerable.ToList();
        }

        [Benchmark]
        public void For_List_Int()
        {
            var sum = 0;
            for (int i = 0; i < listInt.Count; i++)
            {
                sum += listInt[i];
            }
        }

        [Benchmark]
        public void For_IEnumerable_Int()
        {
            var sum = 0;
            for (int i = 0; i < listIntEnumerable.Count(); i++)
            {
                sum += listIntEnumerable.ElementAt(i);
            }
        }

        [Benchmark]
        public void Foreach_List_Int()
        {
            var sum = 0;
            foreach (var number in listInt)
            {
                sum += number;
            }
        }

        [Benchmark]
        public void Foreach_IEnumerable_Int()
        {
            var sum = 0;
            foreach (var number in listIntEnumerable)
            {
                sum += number;
            }
        }

        [Benchmark]
        public void Linq_Sum_List_Int()
        {
            var sum = listInt.Sum();
        }

        [Benchmark]
        public void Linq_Sum_IEnumerable_Int()
        {
            var sum = listIntEnumerable.Sum();
        }
    }
}
