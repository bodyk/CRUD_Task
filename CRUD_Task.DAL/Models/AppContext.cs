using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Task.DAL.Models
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProject>()
                .HasKey(bc => new { bc.UserId, bc.ProjectId });

            modelBuilder.Entity<UserProject>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.UserProjects)
                .HasForeignKey(bc => bc.UserId);

            modelBuilder.Entity<UserProject>()
                .HasOne(bc => bc.Project)
                .WithMany(c => c.UserProjects)
                .HasForeignKey(bc => bc.ProjectId);
        }

        public DbSet<Project> Projects { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
