using BenchmarkDotNet.Attributes;
using Benchmarks.Models;

namespace Benchmarks.NullEmptyChecks
{
    [RankColumn]
    [SimpleJob(iterationCount: 50)]
    public class NullCheckObjectBenchmark
    {
        private User user;

        [Benchmark]
        public void Equal_Operator()
        {
            user = null;
            if (user == null)
            {
                user = new User();
            }
        }

        [Benchmark]
        public void Equals_Method()
        {
            user = null;
            if (Equals(user, null))
            {
                user = new User();
            }
        }

        [Benchmark]
        public void ReferenceEquals_Method()
        {
            user = null;
            if (ReferenceEquals(user, null))
            {
                user = new User();
            }
        }

        [Benchmark]
        public void Is_Operator()
        {
            user = null;
            if (user is null)
            {
                user = new User();
            }
        }

        [Benchmark]
        public void Default_Operator()
        {
            user = null;
            if (user == default)
            {
                user = new User();
            }
        }

        [Benchmark]
        public void Coalesce_Operator()
        {
            user = null;
            user = user ?? new User();
        }

        [Benchmark]
        public void Ternary_Operator()
        {
            user = null;
            user = user == null ? new User() : user;
        }

        [Benchmark]
        public void Is_Operator_Braces()
        {
            user = null;
            if (user is not { })
            {
                user = new User();
            }
        }
    }
}
