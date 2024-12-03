using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solare.Business.Models;

namespace Solare.Data.Mappings
{
    class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Documento)
                .IsRequired()
                .HasColumnType("varchar(14)");

            //1 : 1  => Cliente : Endereco
            builder.HasOne(c => c.EnderecoSimulacao)
                .WithOne(es => es.Cliente);

            //1 : N  => Cliente : Simulacoes
            builder.HasMany(c => c.Simulacoes)
                .WithOne(s => s.Cliente)
                .HasForeignKey(p => p.ClienteId);

            builder.ToTable("Cliente");
        }
    }
}
