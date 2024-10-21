using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Leonardo.Models;

namespace Leonardo.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Folha> Folhas { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=Gabriel_Leonardo.db");
            }
        } 

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funcionario>()
                .HasOne(a => a.Folhas)
                .WithMany(a => a.)
                .HasForeignKey(a => a.FolhaId);

        }*/
    }
}


    
