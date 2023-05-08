using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CantinaFacil.Domain.Aggregates.Estabelecimentos;

namespace CantinaFacil.Infrastructure.Data.Mappings
{
    public class ProdutoMap : Mapping<Produto>
    {
        public override void Map(EntityTypeBuilder<Produto> builder)
        {
            base.Map(builder);

            builder.ToTable("TB_PRODUTO");

            builder.HasKey(x => x.Id)
                .HasName("PK_PRODUTO");

            builder
                .Property(x => x.Id)
                .HasColumnName("CD_PRODUTO");

            builder
                .Property(x => x.EstabelecimentoId)
                .HasColumnName("CD_ESTABELECIMENTO");

            builder
                .Property(x => x.Nome)
                .HasColumnName("NM_PERFIL");

            builder
                .Property(x => x.Valor)
                .HasColumnName("VL_VALOR");

            builder
                .HasOne(x => x.Estabelecimento)
                .WithMany(x => x.Produtos)
                .HasForeignKey(x => x.EstabelecimentoId);
        }
    }
}
