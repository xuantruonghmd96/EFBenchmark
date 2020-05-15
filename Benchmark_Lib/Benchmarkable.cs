using System;
using System.Collections.Generic;
using System.Text;

namespace Benchmark_Lib
{
    public abstract class Benchmarkable
    {
        /// <summary>
        /// How many times we should launch process, 
        /// set it carefully or let it default
        /// </summary>
        public int LauchCount { get; set; }

        /// <summary>
        /// Global setup will be executed only once per a benchmarked method before all the benchmark method invocations
        /// </summary>
        public virtual void GlobalSetup()
        {
            Console.WriteLine("GlobalSetup");
        }
        /// <summary>
        /// Iteration setup will be executed exactly once before each benchmark invocation
        /// </summary>
        public virtual void IterationSetup() 
        {
            Console.WriteLine("IterationSetup");
        }
        public abstract void BenchmarkMethod();
        /// <summary>
        /// Iteration cleanup will be executed exactly once after each benchmark invocation
        /// </summary>
        public virtual void IterationCleanup()
        {
            System.Threading.Thread.Sleep(50);
            Console.WriteLine("IterationCleanup");
        }
        /// <summary>
        /// Global cleanup will be executed only once per a benchmarked method after all the benchmark method invocations
        /// </summary>
        public virtual void GlobalCleanup()
        {
            Console.WriteLine("GlobalCleanup");
        }
    }
}
