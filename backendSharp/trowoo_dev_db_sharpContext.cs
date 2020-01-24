using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using backendSharp.Models;

namespace backendSharp
{
    public partial class trowoo_dev_db_sharpContext : DbContext
    {
        public DbSet<Security> Security {get;set;}
        public trowoo_dev_db_sharpContext()
        {
        }

        public trowoo_dev_db_sharpContext(DbContextOptions<trowoo_dev_db_sharpContext> options)
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
