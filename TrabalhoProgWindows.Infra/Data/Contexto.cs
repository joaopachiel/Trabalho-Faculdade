using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using TrabalhoProgWindows.Entidades.Entidades;

namespace TrabalhoProgWindows.Infra.Data
{
    class Contexto : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().HasMany(x => x.Insumos).WithOne().HasForeignKey(x => x.ProdutoId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Produto>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<ProdutoInsumo>().Property(x => x.Id).ValueGeneratedOnAdd();
        }   

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(RetornarStringConexao());
        }

        private static string RetornarStringConexao()
        {
            return "Integrated Security=SSPI;Persist Security Info=False;" +
                "Initial Catalog=TrabalhoProgWindows;" + 
                @"Data Source=localhost\SQLEXPRESS"; 
        }

        public DbSet<Produto> Produto { get; set; }
        public DbSet<ProdutoInsumo> ProdutoInsumo { get; set; }
    }
}
