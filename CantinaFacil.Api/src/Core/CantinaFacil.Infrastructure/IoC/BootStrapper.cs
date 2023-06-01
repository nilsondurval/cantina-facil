using MediatR;
using Microsoft.Extensions.DependencyInjection;
using CantinaFacil.Domain.Aggregates.Usuarios.Repository;
using CantinaFacil.Domain.Aggregates.Usuarios.Services;
using CantinaFacil.Infrastructure.Data;
using CantinaFacil.Infrastructure.Data.Repository;
using CantinaFacil.Shared.Kernel.Data;
using CantinaFacil.Shared.Kernel.Domain.Events;
using CantinaFacil.Shared.Kernel.Domain.Handlers;
using CantinaFacil.Shared.Kernel.Mediator;
using CantinaFacil.Infrastructure.Auth;
using CantinaFacil.Application.Services.Interfaces;
using CantinaFacil.Application.Services;
using CantinaFacil.Domain.Aggregates.Parametros.Repository;
using CantinaFacil.Domain.Auth.Services;
using CantinaFacil.Domain.Aggregates.Perfis.Repository;
using CantinaFacil.Domain.Aggregates.Estabelecimentos.Services;
using CantinaFacil.Domain.Aggregates.Estabelecimentos.Repository;

namespace CantinaFacil.Infrastructure.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application
            services.AddScoped<ILoginAppService, LoginAppService>();
            services.AddScoped<IParametroAppService, ParametroAppService>();
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();
            services.AddScoped<IPerfilAppService, PerfilAppService>();
            services.AddScoped<IEstabelecimentoAppService, EstabelecimentoAppService>();

            // Mediator
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            // Events            
            services.AddScoped<INotificationHandler<DomainNotificationEvent>, DomainNotificationEventHandler>();

            // Domain
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IEstabelecimentoService, EstabelecimentoService>();
            services.AddScoped<IJwtService, JwtService>();

            // Data
            services.AddScoped<IUnitOfWork, UnitOfWork>();            
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IPerfilRepository, PerfilRepository>();
            services.AddScoped<IEstabelecimentoRepository, EstabelecimentoRepository>();
            services.AddScoped<IParametroRepository, ParametroRepository>();
        }
    }
}
