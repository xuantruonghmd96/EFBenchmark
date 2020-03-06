using Benchmark_Lib;
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
    public class StoredProcedure : Benchmarkable
    {
        DataContext dbContext;
        List<LogModel> res;

        public override void GlobalSetup()
        {
            base.GlobalSetup();
            dbContext = new DataContext();
            string sql = @"
                IF EXISTS (
                        SELECT type_desc, type
                        FROM sys.procedures WITH(NOLOCK)
                        WHERE NAME = 'GetLogs'
                            AND type = 'P'
                      )
                     DROP PROCEDURE dbo.[GetLogs]";
            dbContext.Database.ExecuteSqlCommand(sql);

            sql = @"
            CREATE PROCEDURE [dbo].[GetLogs]
                AS
                BEGIN
                SET NOCOUNT ON
                SELECT [l].[Id], [l].[Active], [l].[BranchId], [l].[Cookies], [l].[CreatedBy], [l].[CreatedDate], [l].[Deleted], [l].[LongSummary], [l].[RequestContentBody], [l].[RequestMethod], [l].[RequestURL], [l].[ResponseContentBody], [l].[ResponseStatusCode], [l].[ShortSummary]
                FROM [Logs] AS [l]
                WHERE CHARINDEX(N'Modules', [l].[RequestURL]) > 0
                ORDER BY (SELECT 1)
                OFFSET 10 ROWS FETCH NEXT 10 ROWS ONLY
                END
            ";
            dbContext.Database.ExecuteSqlCommand(sql);
        }
        public override void GlobalCleanup()
        {
            string sql = @"
                DROP PROCEDURE [dbo].[GetLogs]
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
            string sql = @"
                GetLogs
            ";

            res = dbContext.Logs.FromSqlRaw(sql)
                .Select(x => new LogModel(x))
                .ToList();
        }
    }
}
