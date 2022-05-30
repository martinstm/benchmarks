using BenchmarkDotNet.Attributes;
using Benchmarks.ClassesVsStructs.Models;
using System.Collections.Generic;

namespace Benchmarks.ClassesVsStructs
{
    [RankColumn]
    [MemoryDiagnoser]
    public class ClassStructBenchmark
    {
        [Params(10, 100, 1000)]
        public int size;

        List<UserClass> usersClassList;
        List<UserStruct> usersStructLlist;

        [Benchmark]
        public int UserClass()
        {
            usersClassList = new List<UserClass>(size);

            for (int i = 1; i < size; i++)
            {
                var user = new UserClass();
                user.Id = i;
                user.Name = "User_" + i;
                user.Active = true;

                usersClassList.Add(user);
            }
            return usersClassList.Count;
        }

        [Benchmark]
        public int UserStruct()
        {
            usersStructLlist = new List<UserStruct>(size);

            for (int i = 1; i < size; i++)
            {
                var user = new UserStruct();
                user.Id = i;
                user.Name = "User_" + i;
                user.Active = true;

                usersStructLlist.Add(user);
            }
            return usersStructLlist.Count;
        }
    }
}
