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
        protected DataContext dbContext;
        protected List<Student_2ViewModel> res;

        public override void IterationSetup()
        {
            base.IterationSetup();
            DataContext.UseLazyLoadingProxies = false;
            dbContext = new DataContext();
        }
        public override void IterationCleanup()
        {
            base.IterationCleanup();

            Console.WriteLine(res.Count);
            Console.WriteLine(res.First().Name);
            Console.WriteLine(res.First().Name);
            //foreach (var item in res)
            //{
            //    Console.WriteLine("{0}, GradeName: {1}, TeacherName: {2}", item.Name, item.GradeModel.Name, item.GradeModel.TeacherModel.Name);
            //}

            dbContext.Dispose();
        }

        public override void BenchmarkMethod()
        {
            res = dbContext.Student_2s
                .Include(x => x.Grade)
                .Where(x => x.Name.Contains("111"))
                .Select(x => new Student_2ViewModel { Id = x.Id, GradeId = x.GradeId, Name = x.Name })
                .ToList();
        }
    }
}
