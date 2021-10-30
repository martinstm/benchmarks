using BenchmarkDotNet.Attributes;
using Benchmarks.Models;
using System.Collections.Generic;
using System.Linq;

namespace Benchmarks.ForForeachLinq
{
    [ShortRunJob]
    [RankColumn]
    public class ChangingPropertyBenchmark
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
        public void For_List()
        {
            for (int i = 0; i < listUsers.Count(); i++)
            {
                listUsers[i].Active = false;
            }
        }

        [Benchmark]
        public void Foreach_List()
        {
            foreach (var user in listUsers)
            {
                user.Active = false;
            }
        }

        [Benchmark]
        public void Linq_Select_List()
        {
            var updatedUsers = listUsers.Select(x =>
            {
                x.Active = false;
                return x;
            });
        }

        [Benchmark]
        public void Linq_Select_IEnumerable()
        {
            var updatedUsers = listUsersEnumerable.Select(x =>
            {
                x.Active = false;
                return x;
            });
        }

        [Benchmark]
        public void Linq_Foreach_List()
        {
            listUsers.ForEach(c => c.Active = false);
        }
    }
}
