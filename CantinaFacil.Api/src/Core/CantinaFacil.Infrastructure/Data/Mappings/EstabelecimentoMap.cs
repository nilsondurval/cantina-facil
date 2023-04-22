using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CantinaFacil.Domain.Aggregates.Estabelecimentos;

namespace CantinaFacil.Infrastructure.Data.Mappings
{
    public class EstabelecimentoMap : Mapping<Estabelecimento>
    {
        public override void Map(EntityTypeBuilder<Estabelecimento> builder)
        {
            base.Map(builder);

            builder.ToTable("TB_ESTABELECIMENTO");

            builder.HasKey(x => x.Id)
                .HasName("PK_ESTABELECIMENTO");

            builder
                .Property(x => x.Id)
                .HasColumnName("CD_ESTABELECIMENTO");

            builder
                .Property(x => x.Nome)
                .HasColumnName("NM_PERFIL");

            builder
                .Property(x => x.UsuarioId)
                .HasColumnName("CD_USUARIO");

            builder
                .Property(x => x.Nome)
                .HasColumnName("NM_ESTABELECIMENTO");

            builder
               .Property(x => x.Cnpj)
               .HasColumnName("NR_CNJP");

            builder
                .HasOne(x => x.Usuario)
                .WithMany(x => x.Estabelecimentos)
                .HasForeignKey(x => x.UsuarioId);

            builder
                .HasOne(x => x.Usuario)
                .WithMany(x => x.Estabelecimentos)
                .HasForeignKey(x => x.UsuarioId);
        }
    }
}
