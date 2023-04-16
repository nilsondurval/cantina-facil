using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using CantinaFacil.Domain.Aggregates.Perfis;
using CantinaFacil.Domain.Aggregates.Permissoes;
using CantinaFacil.Domain.Aggregates.Usuarios;
using CantinaFacil.Infrastructure.Data.Mappings.Extensions;
using CantinaFacil.Domain.Aggregates.Parametros;
using Microsoft.EntityFrameworkCore;

namespace CantinaFacil.Infrastructure.Data.Context
{
    public class DataContext : DbContext
    {
        public static ILoggerFactory _loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

        #region DbSets

        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Perfil> Perfis { get; set; }
        public virtual DbSet<Permissao> Permissoes { get; set; }
        public virtual DbSet<Parametro> Parametros { get; set; }

        #endregion

        public DataContext()
        {

        }

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<ValidationFailure>();

            modelBuilder.RegisterModelsMapping();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseLoggerFactory(_loggerFactory)
                .EnableSensitiveDataLogging();
        }
    }
}
