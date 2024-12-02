using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solare.Business.Models;

namespace Solare.Data.Mappings
{
    public class ContatoMapping : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.ToTable("Contato");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Telefone)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(c => c.Email)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.TipoContato)
                .IsRequired()
                .HasConversion<int>();

            builder.Property(c => c.Mensagem)
                .IsRequired(false)
                .HasColumnType("varchar(300)");
        }
    }
}
