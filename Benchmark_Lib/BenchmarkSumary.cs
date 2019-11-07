using System;
using System.Collections.Generic;
using System.Text;

namespace Benchmark_Lib
{
    /// <summary>
    /// Measure in total miliseconds
    /// </summary>
    public class BenchmarkSumary
    {
        public string Name { get; set; }
        public int LauchedCount { get; set; }
        public bool ExceptFistRun { get; set; }
        public double Mean { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public ICollection<double> Elapses { get; set; }

        public override string ToString()
        {
            return $"Name = {Name} \nLauchedCount = {LauchedCount} \nExceptFirstRun = {ExceptFistRun}\nMean = {Mean}  \nMax = {Max} \nMin = {Min}";
        }
    }
}
