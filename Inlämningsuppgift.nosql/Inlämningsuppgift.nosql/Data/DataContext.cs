using System;
using Inlämningsuppgift.nosql.Models;
using Microsoft.EntityFrameworkCore;

namespace Inlämningsuppgift.nosql.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<ProductCatalog> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCatalog>().ToContainer("Products").HasPartitionKey(x => x.Id);
        }
    }
}

