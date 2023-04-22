using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using CantinaFacil.Domain.Aggregates.Perfis;
using CantinaFacil.Domain.Aggregates.Usuarios;
using CantinaFacil.Infrastructure.Data.Mappings.Extensions;
using CantinaFacil.Domain.Aggregates.Parametros;
using Microsoft.EntityFrameworkCore;
using CantinaFacil.Domain.Aggregates.Estabelecimentos;

namespace CantinaFacil.Infrastructure.Data.Context
{
    public class DataContext : DbContext
    {
        public static ILoggerFactory _loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

        #region DbSets

        public virtual DbSet<Usuario> Usuarios => Set<Usuario>();
        public virtual DbSet<UsuarioCantina> UsuariosCantina => Set<UsuarioCantina>();
        public virtual DbSet<Estabelecimento> Estabelecimentos => Set<Estabelecimento>();
        public virtual DbSet<Produto> Produtos => Set<Produto>();
        public virtual DbSet<Perfil> Perfis => Set<Perfil>();
        public virtual DbSet<Permissao> Permissoes => Set<Permissao>();
        public virtual DbSet<Parametro> Parametros => Set<Parametro>();

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
