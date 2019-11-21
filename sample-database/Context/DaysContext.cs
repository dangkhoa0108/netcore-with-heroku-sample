using System;
using Microsoft.EntityFrameworkCore;
using sample_database.Model;

namespace sample_database.Context
{
    public class DaysContext:DbContext
    {
        public DaysContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Days> Days { get; set; }
    }
}
