using Microsoft.EntityFrameworkCore;
using Solare.Business.Models;

namespace Solare.Data.Context
{
    public class SolareDBContext : DbContext
    {
        public SolareDBContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SolareDBContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<EnderecoSimulacao> EnderecoSimulacoes { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Simulacao> Simulacoes { get; set; }
        public DbSet<Contato> Contatos { get; set; }
    }
}
