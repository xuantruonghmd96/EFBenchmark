using Benchmark_Lib;
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
            benchmarkRunner.Benchmarkables.Add(new EagerLoad { LauchCount = 3 });
            benchmarkRunner.Benchmarkables.Add(new LazyLoad { LauchCount = 3 });

            ICollection<BenchmarkSumary> sumaries = benchmarkRunner.Run();

            string resultFilePath = "C:\\ONGOING\\EFBenchmark\\EFcore30Benchmark";
            foreach (var item in sumaries)
            {
                item.WriteToConsole();
                item.WriteToTextFile(resultFilePath);
            }
            BenchmarkSumaryExporter.ExportToExcel(sumaries, 0, resultFilePath);
        }
    }
}
