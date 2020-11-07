using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TestLuisDonoso.Models
{
    public class TestDB : DbContext
    {
        public TestDB() : base("ConnectionStringTest")
        {
        }

        public DbSet<Tarea> Tarea { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Estado> Estado { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarea>().ToTable("TAREA");
            modelBuilder.Entity<Usuario>().ToTable("USUARIO");
            modelBuilder.Entity<Estado>().ToTable("ESTADO");
        }
    }
}