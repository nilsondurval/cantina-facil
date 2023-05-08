using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CantinaFacil.Domain.Aggregates.Usuarios;

namespace CantinaFacil.Infrastructure.Data.Mappings
{
    public class UsuarioCantinaMap : Mapping<UsuarioCantina>
    {
        public override void Map(EntityTypeBuilder<UsuarioCantina> builder)
        {
            base.Map(builder);

            builder.ToTable("TB_USUARIO");

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
                .HasMany(x => x.Estabelecimentos)
                .WithOne(x => x.Usuario)
                .HasForeignKey(x => x.UsuarioId);
        }
    }
}
