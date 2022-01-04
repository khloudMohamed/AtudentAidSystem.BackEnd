using Microsoft.EntityFrameworkCore;
using StudentAidSystem.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAidSystem.Repository
{
    public class SchoolDbContext : DbContext
    {

        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Movements> Movements { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grade>()
                        .HasMany(c => c.Students)
                        .WithOne(e => e.Grade);

            modelBuilder.Entity<Class>()
                            .HasMany(c => c.Students)
                            .WithOne(e => e.Class);

            modelBuilder.Entity<Grade>()
                         .HasOne(a => a.Class)
                         .WithOne(b => b.Grade)
                         .HasForeignKey<Class>(b => b.FK_Class);

            modelBuilder.Entity<Movements>()
                       .HasMany(c => c.Students);
        }
    }
}
