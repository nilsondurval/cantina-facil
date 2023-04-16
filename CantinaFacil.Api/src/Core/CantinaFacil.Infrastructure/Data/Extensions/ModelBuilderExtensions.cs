using Microsoft.EntityFrameworkCore;

namespace CantinaFacil.Infrastructure.Data.Mappings.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void AddConfiguration<TEntity>(this ModelBuilder modelBuilder, EntityTypeConfiguration<TEntity> configuration) where TEntity : class
        {
            configuration.Map(modelBuilder.Entity<TEntity>());
        }

        public static void RegisterModelsMapping(this ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new ParametroMap());
            modelBuilder.AddConfiguration(new PerfilMap());
            modelBuilder.AddConfiguration(new UsuarioMap());
            modelBuilder.AddConfiguration(new PermissaoMap());
            modelBuilder.AddConfiguration(new PerfilPermissaoMap());
        }
    }
}
