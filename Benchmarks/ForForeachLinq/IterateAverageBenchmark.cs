using BenchmarkDotNet.Attributes;
using Benchmarks.Models;
using System.Collections.Generic;
using System.Linq;

namespace Benchmarks.ForForeachLinq
{
    [ShortRunJob]
    [RankColumn]
    public class IterateAverageBenchmark
    {
        private List<User> listUsers;
        private IEnumerable<User> listUsersEnumerable;

        [Params(10, 100, 1000)]
        public int listSize;

        [GlobalSetup]
        public void Setup()
        {
            listUsersEnumerable = Utils.GenerateRandomUserList(listSize);
            listUsers = listUsersEnumerable.ToList();
        }

        [Benchmark]
        public void For_List_Avg()
        {
            var sum = 0;
            for (int i = 0; i < listUsers.Count; i++)
            {
                sum += listUsers[i].ExperienceYears;
            }
            var avg = sum / listUsers.Count;
        }

        [Benchmark]
        public void For_IEnumerable_Avg()
        {
            var sum = 0;
            for (int i = 0; i < listUsersEnumerable.Count(); i++)
            {
                sum += listUsersEnumerable.ElementAt(i).ExperienceYears;
            }
            var avg = sum / listUsersEnumerable.Count();
        }

        [Benchmark]
        public void Foreach_List_Avg()
        {
            var sum = 0;
            foreach (var user in listUsers)
            {
                sum += user.ExperienceYears;
            }
            var avg = sum / listUsers.Count;
        }

        [Benchmark]
        public void Foreach_IEnumerable_Avg()
        {
            var sum = 0;
            foreach (var user in listUsersEnumerable)
            {
                sum += user.ExperienceYears;
            }
            var avg = sum / listUsersEnumerable.Count();
        }

        [Benchmark]
        public void Linq_Avg_List()
        {
            var avg = listUsers.Average(x => x.ExperienceYears);
        }

        [Benchmark]
        public void Linq_Avg_IEnumerable()
        {
            var avg = listUsersEnumerable.Average(x => x.ExperienceYears);
        }
    }
}
