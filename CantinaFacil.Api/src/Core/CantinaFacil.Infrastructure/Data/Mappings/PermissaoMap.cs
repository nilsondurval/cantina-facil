using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CantinaFacil.Domain.Aggregates.Perfis;

namespace CantinaFacil.Infrastructure.Data.Mappings
{
    public class PermissaoMap : Mapping<Permissao>
    {
        public override void Map(EntityTypeBuilder<Permissao> builder)
        {
            base.Map(builder);

            builder.ToTable("TB_PERMISSAO");

            builder
                .HasKey(x => x.Id)
                .HasName("PK_PERMISSAO");

            builder
                .Property(x => x.Id)
                .HasColumnName("CD_PERMISSAO");

            builder
                .Property(x => x.Nome)
                .HasColumnName("NM_PERMISSAO");

            builder
                .Property(x => x.DataCriacao)
                .HasColumnName("DT_CRIACAO");

            builder
                .HasMany(x => x.PerfilPermissoes)
                .WithOne(x => x.Permissao)
                .HasForeignKey(x => x.PermissaoId);
        }
    }
}
