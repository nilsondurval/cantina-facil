using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CantinaFacil.Domain.Aggregates.Usuarios;

namespace CantinaFacil.Infrastructure.Data.Mappings
{
    public class UsuarioMap : Mapping<Usuario>
    {
        public override void Map(EntityTypeBuilder<Usuario> builder)
        {
            base.Map(builder);

            builder.ToTable("TB_USUARIO");

            builder
                .HasDiscriminator<string>("TP_USUARIO")
                .HasValue<UsuarioCantina>("Cantina");

            builder
                .HasKey(x => x.Id)
                .HasName("PK_USUARIO");

            builder
                .Property(x => x.Id)
                .HasColumnName("CD_USUARIO");

            builder
                .Property(x => x.PerfilId)
                .HasColumnName("CD_PERFIL");

            builder
                .Property(x => x.Cpf)
                .HasColumnName("NR_CPF");

            builder
                .Property(x => x.Nome)
                .HasColumnName("NM_USUARIO");

            builder
                .Property(x => x.Email)
                .HasColumnName("TX_EMAIL");

            builder
                .Property(x => x.Senha)
                .HasColumnName("TX_SENHA");

            builder
                .Property(x => x.Telefone)
                .HasColumnName("TX_TELEFONE");

            builder
                .Property(x => x.DataCriacao)
                .HasColumnName("DT_CRIACAO");

            builder
                .HasOne(x => x.Perfil)
                .WithMany(x => x.Usuarios)
                .HasForeignKey(x => x.PerfilId);
        }
    }
}
