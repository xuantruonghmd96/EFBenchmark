using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Models_Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFcore30Benchmark.Data
{
    public class DataContext : DbContext
    {
        public static readonly ILoggerFactory MyLoggerFactory
       = LoggerFactory.Create(builder => { builder.AddConsole(); }); 
        public static bool UseLazyLoadingProxies = false;

        public DbSet<Student_2> Student_2s { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder
                .UseLoggerFactory(MyLoggerFactory) // Warning: Do not create a new ILoggerFactory instance each time
                .UseSqlServer(@"Server=.;Database=StudentCourse;Trusted_Connection=True;MultipleActiveResultSets=true");

            optionsBuilder.UseLazyLoadingProxies();
            if (UseLazyLoadingProxies)
                optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
