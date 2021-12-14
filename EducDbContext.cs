using EducWebApi.Controllers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducWebApi.Models
{
    public class EducDbContext : DbContext 
    { //Db Sets Here
        public virtual DbSet<Major> Majors { get; set; }
        public virtual DbSet<Student> Students { get; set; }
      
        public EducDbContext(DbContextOptions<EducDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        { builder.Entity<Major>(e => { e.ToTable("Majors"); //Table name
            e.HasKey(p => p.Id); // primary key
            e.Property(p => p.Code).HasMaxLength(15).IsRequired(true);
            e.HasIndex(p => p.Code).IsUnique(true);
            e.Property(p => p.Description).HasMaxLength(30).IsRequired(true);
            e.Property(p => p.MinSat);
        }); 
            builder.Entity<Student>(e => {
                e.ToTable("Students");
                e.HasKey(p => p.Id);
                e.Property(p => p.Firstname).HasMaxLength(30).IsRequired(true);
                e.Property(p => p.Lastname).HasMaxLength(30).IsRequired(true);
                e.Property(p => p.SAT);
                e.Property(p => p.GPA).HasColumnType("decimal(5,1)");
                e.HasOne(p => p.Major).WithMany(p => p.Students)
                .HasForeignKey(p => p.MajorId).OnDelete(DeleteBehavior.Restrict);
            }); }
    }
}
