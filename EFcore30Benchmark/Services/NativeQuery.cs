﻿using Benchmark_Lib;
using EFcore30Benchmark.Data;
using Microsoft.EntityFrameworkCore;
using Models_Lib.Models;
using Models_Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFcore30Benchmark
{
    class NativeQuery : Benchmarkable
    {
        DataContext dbContext;
        List<Student_2> res;

        public override void IterationSetup()
        {
            base.IterationSetup();
            dbContext = new DataContext();
        }
        public override void IterationCleanup()
        {
            base.IterationCleanup();

            Console.WriteLine(res.Count);
            Console.WriteLine(res.First().Name);
            Console.WriteLine(res.First().Name);
            foreach (var item in res)
            {
                Console.WriteLine("{0}, GradeName: {1}, TeacherName: {2}", item.Name, item.Grade.Name, item.Grade.Teacher.Name);
            }

            dbContext.Dispose();
        }

        public override void BenchmarkMethod()
        {
            string sql = @"
                SELECT [s].[Id], [s].[GradeId], [s].[Name], [g].[Id] as gId, [g].[Name] as gName, [g].[TeacherId], [t].[Id] as tId, [t].[Name] as tName
                FROM [Student_2s] AS [s]
                INNER JOIN [Grades] AS [g] ON [s].[GradeId] = [g].[Id]
                INNER JOIN [Teachers] AS [t] ON [g].[TeacherId] = [t].[Id]
                WHERE ([s].[Id] % 1000) = 0
                ORDER BY (SELECT 1)
                OFFSET 10 ROWS FETCH NEXT 10 ROWS ONLY
            ";

            res = dbContext.Student_2s.FromSqlRaw(sql)
                .ToList();
        }
    }
}
