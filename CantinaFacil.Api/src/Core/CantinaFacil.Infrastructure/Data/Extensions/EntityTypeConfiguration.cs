using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CantinaFacil.Infrastructure.Data.Mappings.Extensions
{
    public abstract class EntityTypeConfiguration<TEntity> where TEntity : class
    {
        public abstract void Map(EntityTypeBuilder<TEntity> builder);
    }
}
