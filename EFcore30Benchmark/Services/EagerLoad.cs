using Benchmark_Lib;
using EFcore30Benchmark.Data;
using Microsoft.EntityFrameworkCore;
using Models_Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFcore30Benchmark
{
    public class EagerLoad : Benchmarkable
    {
        DataContext dbContext;
        List<LogModel> res;

        public override void IterationSetup()
        {
            base.IterationSetup();
            dbContext = new DataContext();
        }
        public override void IterationCleanup()
        {
            base.IterationCleanup();

            Console.WriteLine(res.Count);
            Console.WriteLine(res.First().RequestURL);
            Console.WriteLine(res.First().RequestURL);
            foreach (var item in res)
            {
                Console.WriteLine("{0}, GradeName: {1}, TeacherName: {2}", item.Id, item.RequestURL, item.RequestMethod);
            }

            dbContext.Dispose();
        }

        public override void BenchmarkMethod()
        {
            res = dbContext.Logs
                .Where(x => x.RequestURL.Contains("Modules"))
                .Skip(10).Take(10)
                .Select(x => new LogModel(x))
                .ToList();
        }
    }
}
