using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solare.Business.Models;

namespace Solare.Data.Mappings
{
    public class SimulacaoMapping : IEntityTypeConfiguration<Simulacao>
    {
        public void Configure(EntityTypeBuilder<Simulacao> builder)
        {

            builder.ToTable("Simulacao");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.TipoImovel)
                .IsRequired()
                .HasConversion<int>();

            builder.Property(s => s.OrcamentoMaximo)
                .IsRequired()
                .HasColumnType("decimal(17,2)");

            builder.Property(s => s.ConsumoMedioMensal)
                .IsRequired()
                .HasColumnType("decimal(17,2)");

            builder.Property(s => s.ValorMedioContaEnergia)
                .IsRequired()
                .HasColumnType("decimal(17,2)");

            builder.Property(s => s.AnosPermanencia)
                .IsRequired()
                .HasColumnType("integer");

            builder.Property(s => s.EspacoTotalInstalacao)
                .IsRequired()
                .HasColumnType("decimal(17,2)");

            //1 : 1  => Simulacao : Endereco
            builder.HasOne(s => s.EnderecoSimulacao)
                .WithOne(e => e.Simulacao);
        }
    }
}
