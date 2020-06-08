using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Trowoo.Models;

namespace Trowoo
{
    public partial class TrowooDbContext : DbContext
    {
        public DbSet<Security> Securities {get; set;}
        public DbSet<Portfolio> Portfolios {get; set;}
        public DbSet<Position> Positions {get; set;}
        public DbSet<Quote> Quotes {get; set;}
        public DbSet<LowPrice> LowPrices {get; set;}
        public DbSet<HighPrice> HighPrices {get; set;}
        public DbSet<TrailingStop> TrailingStops {get; set;}
        public DbSet<PositionPerformanceMetrics> PositionPerformanceMetrics {get; set;}
        public TrowooDbContext()
        {
        }

        public TrowooDbContext(DbContextOptions<TrowooDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=trowoo_dev_db_sharp;Username=root;Password=root");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
