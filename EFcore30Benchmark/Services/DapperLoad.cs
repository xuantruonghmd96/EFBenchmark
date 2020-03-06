using Benchmark_Lib;
using Dapper;
using EFcore30Benchmark.Data;
using Microsoft.Data.SqlClient;
using Models_Lib.Models;
using Models_Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFcore30Benchmark
{
    public class DapperLoad : Benchmarkable
    {
        SqlConnection connection;
        List<Log> res;

        public override void IterationSetup()
        {
            base.IterationSetup();
            connection = new SqlConnection("Server=.;Database=ECR-BO-Retail;Trusted_Connection=True;MultipleActiveResultSets=true");
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

            connection.Dispose();
        }

        public override void BenchmarkMethod()
        {
            string sql = @"SELECT [l].[Id], [l].[Active], [l].[BranchId], [l].[Cookies], [l].[CreatedBy], [l].[CreatedDate], [l].[Deleted], [l].[LongSummary], [l].[RequestContentBody], [l].[RequestMethod], [l].[RequestURL], [l].[ResponseContentBody], [l].[ResponseStatusCode], [l].[ShortSummary]
                FROM [Logs] AS [l]
                WHERE CHARINDEX(N'Modules', [l].[RequestURL]) > 0
                ORDER BY (SELECT 1)
                OFFSET 10 ROWS FETCH NEXT 10 ROWS ONLY";

            res = connection.Query<Log>(sql).ToList();
        }
    }
}
