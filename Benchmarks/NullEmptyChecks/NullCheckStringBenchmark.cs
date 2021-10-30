using BenchmarkDotNet.Attributes;

namespace Benchmarks.NullEmptyChecks
{
    [RankColumn]
    [SimpleJob(targetCount: 50)]
    public class NullCheckStringBenchmark
    {
        private string str;
        private string message = "value is null";

        [Benchmark]
        public void Equal_Operator()
        {
            str = null;
            if (str == null)
            {
                str = message;
            }
        }

        [Benchmark]
        public void Equals_Method()
        {
            str = null;
            if (string.Equals(str, null))
            {
                str = message;
            }
        }

        [Benchmark]
        public void ReferenceEquals_Method()
        {
            str = null;
            if (ReferenceEquals(null, str))
            {
                str = message;
            }
        }

        [Benchmark]
        public void Is_Operator()
        {
            str = null;
            if (str is null)
            {
                str = message;
            }
        }

        [Benchmark]
        public void NullOrEmpty_Method()
        {
            str = null;
            if (string.IsNullOrEmpty(str))
            {
                str = message;
            }
        }

        [Benchmark]
        public void Default_Operator()
        {
            str = null;
            if (str == default)
            {
                str = message;
            }
        }

        [Benchmark]
        public void Coalesce_Operator()
        {
            str = null;
            str = str ?? message;
        }

        [Benchmark]
        public void Ternary_Operator()
        {
            str = null;
            str = str == null ? message : str;
        }

        [Benchmark]
        public void Is_Operator_Braces()
        {
            str = null;
            if (str is not { })
            {
                str = message;
            }
        }
    }
}
