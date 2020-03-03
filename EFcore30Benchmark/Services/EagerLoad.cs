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
        List<Student_2ViewModel> res;

        public override void IterationSetup()
        {
            base.IterationSetup();
            dbContext = new DataContext();
        }
        public override void IterationCleanup()
        {
            base.IterationCleanup();

            Console.WriteLine(res.Count);
            Console.WriteLine(res.First().GradeModel.Name);
            Console.WriteLine(res.First().GradeModel.Name);
            foreach (var item in res)
            {
                Console.WriteLine("{0}, GradeName: {1}, TeacherName: {2}", item.Name, item.GradeModel.Name, item.GradeModel.TeacherModel.Name);
            }

            dbContext.Dispose();
        }

        public override void BenchmarkMethod()
        {
            res = dbContext.Student_2s
                .Include(x => x.Grade).ThenInclude(x => x.Teacher)
                .Where(x => x.Id % 1000 == 0)
                .Skip(10).Take(10)
                .Select(x => new Student_2ViewModel(x))
                .ToList();
        }
    }
}
