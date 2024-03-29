﻿using BenchmarkDotNet.Running;
using Benchmarks.ClassesVsStructs;
using Benchmarks.DictionaryListKeyValuePair;
using Benchmarks.ForForeachLinq;
using Benchmarks.NullEmptyChecks;
using Benchmarks.Strings;

namespace Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            #region For | Foreach | LINQ
            //BenchmarkRunner.Run<IterateSumBenchmark>();
            //BenchmarkRunner.Run<IterateAverageBenchmark>();
            //BenchmarkRunner.Run<ChangingPropertyBenchmark>();
            //BenchmarkRunner.Run<FindListsBenchmark>();
            #endregion

            #region Null Checks
            //BenchmarkRunner.Run<NullCheckObjectBenchmark>();
            //BenchmarkRunner.Run<NullCheckStringBenchmark>();
            //BenchmarkRunner.Run<CheckEmptyListsBenchmark>();
            #endregion

            #region Strings
            //BenchmarkRunner.Run<ConcatenateBenchmark>();
            #endregion

            #region Classes VS Structs
            //BenchmarkRunner.Run<ClassStructBenchmark>();
            #endregion

            #region Dictionary VS Lists VS KeyValuePair
            BenchmarkRunner.Run<DictionaryVsLists>();
            #endregion
        }
    }
}
