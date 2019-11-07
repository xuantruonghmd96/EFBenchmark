using Benchmark_Lib;
using EFcore30Benchmark.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace EFcore30Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            BenchmarkRunner benchmarkRunner = new BenchmarkRunner(new GaussianStopFlag());
            benchmarkRunner.ExceptFirstRun = true;
            benchmarkRunner.Benchmarkables.Add(new EagerLoad());

            ICollection<BenchmarkSumary> sumaries = benchmarkRunner.Run();
            foreach (var item in sumaries)
            {
                Console.WriteLine("--------------------------------------------------------------");
                Console.WriteLine(item.ToString());
                Console.WriteLine("--------------------------------------------------------------");
            }
        }
    }
}
