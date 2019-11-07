﻿using Benchmark_Lib;
using EFcore30Benchmark.Data;
using Microsoft.EntityFrameworkCore;
using Models_Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFcore30Benchmark.Services
{
    public class EagerLoad : Benchmarkable
    {
        DataContext dbContext;

        public override void IterationSetup()
        {
            Console.WriteLine("IterationSetup");
            dbContext = new DataContext();
        }

        public override void BenchmarkMethod()
        {
            var res = dbContext.Student_2s
                .Where(x => x.Id % 1000 == 0)
                .Select(x => new Student_2ViewModel(x))
                .ToList();

            Console.WriteLine(res.First().GradeModel.Name);
            Console.WriteLine(res.First().GradeModel.Name);
            Console.WriteLine(res.First().GradeModel.Name);

            foreach (var item in res)
            {
            }
        }
    }
}
