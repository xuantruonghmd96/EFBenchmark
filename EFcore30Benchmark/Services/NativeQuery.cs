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
    class NativeQuery : Benchmarkable
    {
        DataContext dbContext;

        public override void IterationSetup()
        {
            base.IterationSetup();
            dbContext = new DataContext();
        }
        public override void IterationCleanup()
        {
            base.IterationCleanup();
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
            ";

            var res = dbContext.Student_2s.FromSqlRaw(sql)
                .ToList();

            Console.WriteLine(res.First().Name);
            Console.WriteLine(res.First().Name);
        }
    }
}
