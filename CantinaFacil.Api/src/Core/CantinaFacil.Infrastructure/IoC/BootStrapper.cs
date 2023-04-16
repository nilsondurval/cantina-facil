using MediatR;
using Microsoft.Extensions.DependencyInjection;
using CantinaFacil.Domain.Aggregates.Usuarios.Repository;
using CantinaFacil.Domain.Aggregates.Usuarios.Services;
using CantinaFacil.Domain.Authentication;
using CantinaFacil.Infrastructure.Data;
using CantinaFacil.Infrastructure.Data.Context;
using CantinaFacil.Infrastructure.Data.Repository;
using CantinaFacil.Shared.Kernel.Data;
using CantinaFacil.Shared.Kernel.Domain.Events;
using CantinaFacil.Shared.Kernel.Domain.Handlers;
using CantinaFacil.Shared.Kernel.Mediator;
using CantinaFacil.Infrastructure.Authentication;
using CantinaFacil.Application.Services.Interfaces;
using CantinaFacil.Application.Services;
using CantinaFacil.Domain.Aggregates.Parametros.Repository;

namespace CantinaFacil.Infrastructure.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application
            services.AddScoped<ILoginAppService, LoginAppService>();
            services.AddScoped<IParametroAppService, ParametroAppService>();

            // Mediator
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            // Events            
            services.AddScoped<INotificationHandler<DomainNotificationEvent>, DomainNotificationEventHandler>();

            // Domain
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IJwtService, JwtService>();

            // Data
            services.AddScoped<DataContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();            
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IParametroRepository, ParametroRepository>();
        }
    }
}
