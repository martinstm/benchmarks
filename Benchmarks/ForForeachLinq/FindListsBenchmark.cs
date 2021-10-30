using BenchmarkDotNet.Attributes;
using Benchmarks.Models;
using System.Collections.Generic;
using System.Linq;

namespace Benchmarks.ForForeachLinq
{
    [ShortRunJob]
    [MemoryDiagnoser, RankColumn]
    public class FindListsBenchmark
    {
        private List<User> listUsers;
        private IEnumerable<User> listIEnumerableUsers;

        private string targetUser = "James";

        [Params(10, 100, 1000)]
        public int listSize;

        [GlobalSetup]
        public void Setup()
        {
            listIEnumerableUsers = Utils.GenerateRandomUserList(listSize);
            listUsers = listIEnumerableUsers.ToList();
        }

        [Benchmark]
        public void For_List()
        {
            var result = new List<User>();

            for (int i = 0; i < listUsers.Count; i++)
            {
                if (listUsers[i].Name == targetUser)
                {
                    result.Add(listUsers[i]);
                }
            }
        }

        [Benchmark]
        public void Foreach_List()
        {
            var result = new List<User>();

            foreach (var user in listUsers)
            {
                if(user.Name == targetUser)
                {
                    result.Add(user);
                }
            }
        }

        [Benchmark]
        public void Foreach_IEnumerable()
        {
            var result = new List<User>();

            foreach (var user in listIEnumerableUsers)
            {
                if (user.Name == targetUser)
                {
                    result.Add(user);
                }
            }
        }

        [Benchmark]
        public void FindAll_List()
        {
            var result = listUsers.FindAll(x => x.Name == targetUser);
        }

        [Benchmark]
        public void Linq_Where_List()
        {
            var result = listUsers.Where(x => x.Name == targetUser);
        }

        [Benchmark]
        public void Linq_Where_IEnumerable()
        {
            var result = listIEnumerableUsers.Where(x => x.Name == targetUser);
        }

        [Benchmark]
        public void Linq_Where_List_ToList()
        {
            var result = listUsers.Where(x => x.Name == targetUser).ToList();
        }

        [Benchmark]
        public void Linq_Where_IEnumerable_ToList()
        {
            var result = listIEnumerableUsers.Where(x => x.Name == targetUser).ToList();
        }
    }
}
