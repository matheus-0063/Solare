using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solare.Business.Models;

namespace Solare.Data.Mappings
{
    class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.TipoProduto)
                .IsRequired()
                .HasConversion<int>();

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(1000)");

            builder.Property(p => p.Valor)
                .IsRequired();

            builder.Property(p => p.DimensaoEmMtQuadrado)
                .IsRequired(false);

            builder.Property(p => p.Eficiencia)
                .IsRequired(false);

            builder.Property(p => p.Potencia)
                .IsRequired(false);

            builder.Property(p => p.Corrente)
                .IsRequired(false);

            builder.Property(p => p.Tensao)
                .IsRequired(false);

            builder.Property(p => p.Saida)
                .IsRequired(false);

            builder.ToTable("Produtos");
        }
    }
}
