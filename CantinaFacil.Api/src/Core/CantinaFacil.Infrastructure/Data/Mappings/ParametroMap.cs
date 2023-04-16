using CantinaFacil.Domain.Aggregates.Parametros;
using CantinaFacil.Infrastructure.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CantinaFacil.Infrastructure.Data.Mappings
{
    public class ParametroMap : Mapping<Parametro>
    {
        public override void Map(EntityTypeBuilder<Parametro> builder)
        {
            base.Map(builder);

            builder.ToTable("TB_PARAMETRO");

            builder
                .HasKey(x => x.Id)
                .HasName("PK_PARAMETRO");

            builder
                .Property(x => x.Id)
                .HasColumnName("CD_PARAMETRO");

            builder
                .Property(x => x.Nome)
                .HasColumnName("NM_PARAMETRO");

            builder
                .Property(x => x.Valor)
                .HasColumnName("TX_VALOR");

            builder
               .Property(x => x.Descricao)
               .HasColumnName("DS_PARAMETRO");
        }
    }
}
