using ConsoleApp.Aula5.EntityMapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace ConsoleApp.Aula5
{
    public class ApplicationContext : DbContext
    {
        private const string stringDeConexao = @"Server=localhost;Port=3306;Database=dbaula;User Id=root;Password=root;";

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Autor> Autores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 25));
            
            optionsBuilder.UseMySql(stringDeConexao, serverVersion)
                          .EnableDetailedErrors(); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
