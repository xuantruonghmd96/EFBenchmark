using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Benchmark_Lib
{
    public class BenchmarkRunner
    {
        public ICollection<Benchmarkable> Benchmarkables { get; set; }
        IStopFlag _stopFlag;
        public bool ExceptFirstRun { get; set; }

        public BenchmarkRunner(IStopFlag stopFlag)
        {
            Benchmarkables = new HashSet<Benchmarkable>();
            _stopFlag = stopFlag;
        }

        public ICollection<BenchmarkSumary> Run() 
        {
            ICollection<BenchmarkSumary> sumaries = new HashSet<BenchmarkSumary>();

            foreach (var item in Benchmarkables)
            {
                Console.WriteLine();
                Console.WriteLine("--- Benchmark {0}", item.GetType().ToString());
                item.GlobalSetup();
                sumaries.Add(Iterate(item));
                item.GlobalCleanup();
                Console.WriteLine("----------------------------------------------------------");
            }

            return sumaries;
        }

        private BenchmarkSumary Iterate(Benchmarkable benchmarkable)
        {
            int lauchCount = benchmarkable.LauchCount == 0 ? 1000 : benchmarkable.LauchCount;
            int lauched = 0;
            double firstRunElapsed = 0;
            ICollection<double> eslapses = new HashSet<double>();
            while (lauched < lauchCount && !_stopFlag.CanStopHere(eslapses))
            {
                Console.WriteLine("--- --- Iterator {0}", lauched);
                benchmarkable.IterationSetup();

                Stopwatch sw = new Stopwatch();
                sw.Start();
                benchmarkable.BenchmarkMethod();
                sw.Stop();
                if (lauched > 0)
                    eslapses.Add(sw.Elapsed.TotalMilliseconds);
                else
                {
                    firstRunElapsed = sw.Elapsed.TotalMilliseconds;
                    if (!ExceptFirstRun)
                        eslapses.Add(sw.Elapsed.TotalMilliseconds);
                }

                benchmarkable.IterationCleanup();
                Console.WriteLine("      Elapsed {0} miliseconds", sw.Elapsed.TotalMilliseconds);
                lauched++;
            }

            BenchmarkSumary sumary = new BenchmarkSumary
            {
                Name = benchmarkable.GetType().ToString(),
                LauchedCount = eslapses.Count,
                ExceptFistRun = this.ExceptFirstRun,
                FirstRunElapsed = firstRunElapsed,
                Mean = eslapses.Average(),
                Max = eslapses.Max(),
                Min = eslapses.Min(),
                Elapses = eslapses
            };
            return sumary;
        }
    }
}
