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
        List<Student_2> res;

        public override void IterationSetup()
        {
            base.IterationSetup();
            connection = new SqlConnection("Server=.;Database=StudentCourse;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        public override void IterationCleanup()
        {
            base.IterationCleanup();

            Console.WriteLine(res.Count);
            Console.WriteLine(res.First().Grade.Name);
            Console.WriteLine(res.First().Grade.Name);
            foreach (var item in res)
            {
                Console.WriteLine("{0}, GradeName: {1}, TeacherName: {2}", item.Name, item.Grade.Name, item.Grade.Teacher.Name);
            }

            connection.Dispose();
        }

        public override void BenchmarkMethod()
        {
            string sql = @"SELECT [s].[Id], [s].[GradeId], [s].[Name], [g].[Id] as Id, [g].[Name] as Name, [g].[TeacherId], [t].[Id] as Id, [t].[Name] as Name
                FROM [Student_2s] AS [s]
                INNER JOIN [Grades] AS [g] ON [s].[GradeId] = [g].[Id]
                INNER JOIN [Teachers] AS [t] ON [g].[TeacherId] = [t].[Id]
                WHERE ([s].[Id] % 1000) = 0
                ORDER BY (SELECT 1)
                OFFSET 10 ROWS FETCH NEXT 10 ROWS ONLY";

            res = connection.Query<Student_2, Grade, Teacher, Student_2>(sql, (student, grade, teacher) =>
            {
                grade.Teacher = teacher;
                student.Grade = grade;
                return student;
            })
            .ToList();
        }
    }
}
