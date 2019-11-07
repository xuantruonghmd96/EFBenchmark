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
    public class StoredProcedure : Benchmarkable
    {
        DataContext dbContext;

        public override void GlobalSetup()
        {
            base.GlobalSetup();
            dbContext = new DataContext();
            string sql = @"
                IF EXISTS (
                        SELECT type_desc, type
                        FROM sys.procedures WITH(NOLOCK)
                        WHERE NAME = 'GetStudent_2s'
                            AND type = 'P'
                      )
                     DROP PROCEDURE dbo.[GetStudent_2s]";
            dbContext.Database.ExecuteSqlCommand(sql);

            sql = @"
            CREATE PROCEDURE [dbo].[GetStudent_2s]
                AS
                BEGIN
                SET NOCOUNT ON
                SELECT [s].[Id], [s].[GradeId], [s].[Name], [g].[Id] as gId, [g].[Name] as gName, [g].[TeacherId], [t].[Id] as tId, [t].[Name] as tName
                    FROM [Student_2s] AS [s]
                    INNER JOIN [Grades] AS [g] ON [s].[GradeId] = [g].[Id]
                    INNER JOIN [Teachers] AS [t] ON [g].[TeacherId] = [t].[Id]
                    WHERE ([s].[Id] % 1000) = 0
                END
            ";
            dbContext.Database.ExecuteSqlCommand(sql);
        }
        public override void GlobalCleanup()
        {
            string sql = @"
                DROP PROCEDURE [dbo].[GetStudent_2s]
            ";
            dbContext = new DataContext();
            dbContext.Database.ExecuteSqlCommand(sql);
        }
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
                GetStudent_2s
            ";

            var res = dbContext.Student_2s.FromSqlRaw(sql)
                .ToList();

            Console.WriteLine(res.First().Name);
            Console.WriteLine(res.First().Name);
        }
    }
}
