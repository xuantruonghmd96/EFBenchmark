using System;
using System.Collections.Generic;
using System.IO;
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
        public double FirstRunElapsed { get; set; }
        public double Mean { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public ICollection<double> Elapses { get; set; }

        public override string ToString()
        {
            return $"Name = {Name} \nLauchedCount = {LauchedCount} \nExceptFirstRun = {ExceptFistRun}\nFirstRunElapsed = {FirstRunElapsed} \nMean = {Mean}  \nMax = {Max} \nMin = {Min}";
        }

        public void WriteToConsole()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine(this.ToString());
            Console.WriteLine("--------------------------------------------------------------");
            Console.ResetColor();
        }

        public void WriteToTextFile(string filePath = "")
        {
            filePath += "EFBenchmark_Result.txt";
            using (StreamWriter w = File.AppendText(filePath))
            {
                w.WriteLine("--------------------------------------------------------------");
                w.WriteLine(this.ToString());
                foreach (var item in this.Elapses)
                    w.Write("{0}\t", item);
                w.WriteLine();
                w.WriteLine("--------------------------------------------------------------");
                w.Close();
            }
        }
    }
}
