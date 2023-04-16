using CantinaFacil.Domain.Aggregates.Perfis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CantinaFacil.Infrastructure.Data.Mappings
{
    public class PerfilPermissaoMap : Mapping<PerfilPermissao>
    {
        public override void Map(EntityTypeBuilder<PerfilPermissao> builder)
        {
            base.Map(builder);

            builder.ToTable("TB_PERFIL_PERMISSAO");

            builder
                .HasKey(x => x.Id)
                .HasName("PK_SUBPERFIL_PERMISSAO");

            builder
                .Property(x => x.Id)
                .HasColumnName("CD_SUBPERFIL_PERMISSAO");

            builder
               .Property(x => x.PerfilId)
               .HasColumnName("CD_PERFIL");

            builder
               .Property(x => x.PermissaoId)
               .HasColumnName("CD_PERMISSAO");

            builder
                .HasOne(x => x.Perfil)
                .WithMany(x => x.PerfilPermissoes)
                .HasForeignKey(x => x.PerfilId);

            builder
                .HasOne(x => x.Permissao)
                .WithMany(x => x.PerfilPermissoes)
                .HasForeignKey(x => x.PermissaoId);
        }
    }
}
