using Benchmark_Lib;
using EFcore30Benchmark.Data;
using Models_Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFcore30Benchmark
{
    public class LazyLoad : EagerLoad
    {
        DataContext dbContext;

        public override void IterationSetup()
        {
            base.IterationSetup();
            DataContext.UseLazyLoadingProxies = true;
            dbContext = new DataContext();
        }

        public override void BenchmarkMethod()
        {
            res = dbContext.Student_2s
                .Where(x => x.Id == 999997)
                .Select(x => new Student_2ViewModel(x))
                .ToList();
        }
    }
}
