﻿using DominandoEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominandoEFCore.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string strConnection = "Data Source=DESKTOP-B76722G\\SQLEXPRESS; Initial Catalog=DominandoEFCoreV2; User ID=developer; Password=dev*10; Integrated Security=True; Persist Security Info=False; Pooling=False; MultipleActiveResultSets=False; Encrypt=False; Trusted_Connection=False";

            optionsBuilder.UseSqlServer(strConnection)
                          .LogTo(Console.WriteLine, LogLevel.Information)
                          .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>(conf => 
            {
                conf.HasKey(pessoa => pessoa.Id);
                conf.Property(pessoa => pessoa.Nome)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });
        }
    }
}