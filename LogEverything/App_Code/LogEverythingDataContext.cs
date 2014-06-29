using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using LogEverything.Models;

namespace LogEverything
{
    public class LogEverythingDataContext : DbContext
    {
        public LogEverythingDataContext(string connectionString)
            : base(connectionString)
        {
        }

        public DbSet<LogItem> Logs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LogItem>().HasKey(o => o.LogID);
            modelBuilder.Entity<LogItem>().ToTable("Logs");
        }
    }
}