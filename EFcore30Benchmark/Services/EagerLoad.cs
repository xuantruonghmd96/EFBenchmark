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
        protected List<Student_2ViewModel> res = new List<Student_2ViewModel>();

        public override void IterationSetup()
        {
            base.IterationSetup();
            DataContext.UseLazyLoadingProxies = false;
            dbContext = new DataContext();
        }
        public override void IterationCleanup()
        {
            base.IterationCleanup();
            dbContext.Dispose();

            Console.WriteLine(res.First().GradeModel.Name);
            Console.WriteLine(res.First().GradeModel.Name);
        }

        public override void BenchmarkMethod()
        {
            res = dbContext.Student_2s
                .Include(x => x.Grade).ThenInclude(x => x.Teacher)
                .Where(x => x.Id == 999997)
                .Select(x => new Student_2ViewModel(x))
                .ToList();
        }
    }
}
