using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CantinaFacil.Domain.Aggregates.Perfis;

namespace CantinaFacil.Infrastructure.Data.Mappings
{
    public class PerfilMap : Mapping<Perfil>
    {
        public override void Map(EntityTypeBuilder<Perfil> builder)
        {
            base.Map(builder);

            builder.ToTable("TB_DOM_PERFIL");

            builder.HasKey(x => x.Id)
                .HasName("PK_PERFIL");

            builder
                .Property(x => x.Id)
                .HasColumnName("CD_PERFIL");

            builder
                .Property(x => x.Nome)
                .HasColumnName("NM_PERFIL");

            builder
                .Property(x => x.DataCriacao)
                .HasColumnName("DT_CRIACAO");

            builder
                .HasMany(x => x.PerfilPermissoes)
                .WithOne(x => x.Perfil)
                .HasForeignKey(x => x.PerfilId);

            builder
                .HasMany(x => x.Usuarios)
                .WithOne(x => x.Perfil)
                .HasForeignKey(x => x.PerfilId);
        }
    }
}
