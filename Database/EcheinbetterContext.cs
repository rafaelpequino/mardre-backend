using Echeinbetter.Models;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;

namespace Echeinbetter.Database
{
    public class EngenhariasSenacContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; } = null!;
        public DbSet<MateriaPrima> MateriasPrimas { get; set; } = null!;
        public DbSet<Processamento> Processamentos { get; set; } = null!;

        private readonly string? connectionString;

        public EngenhariasSenacContext()
        {
            Env.Load();
            connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new InvalidOperationException("CONNECTION_STRING environment variable not found");

            optionsBuilder.UseSqlServer(connectionString, options =>
            {
                options.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(10),
                    errorNumbersToAdd: null
                );
            });
        }
    }
}
