using MediatR;
using CantinaFacil.Application.Services.Interfaces;
using CantinaFacil.Domain.Aggregates.Parametros.Enumeration;
using CantinaFacil.Domain.Aggregates.Parametros.Repository;
using CantinaFacil.Shared.Kernel.Application;
using CantinaFacil.Shared.Kernel.Data;
using CantinaFacil.Shared.Kernel.Domain.Events;
using CantinaFacil.Shared.Kernel.Mediator;

namespace CantinaFacil.Application.Services
{
    public class ParametroAppService : ApplicationService, IParametroAppService
    {
        private readonly IParametroRepository _parametroRepository;

        public ParametroAppService(IUnitOfWork unitOfWork, 
                                   IMediatorHandler mediator, 
                                   INotificationHandler<DomainNotificationEvent> notifications,
                                   IParametroRepository parametroRepository) : base(unitOfWork, mediator, notifications)
        {
            _parametroRepository = parametroRepository;
        }        

        public async Task<string> ObterChavePrivadaJwtAsync()
        {
            var parametro = await _parametroRepository.ObterParametroPorChaveAsync(ParametroChave.JwtPrivateKey);
            return parametro.Valor;
        }

        public async Task<string> ObterChavePublicaJwtAsync()
        {
            var parametro = await _parametroRepository.ObterParametroPorChaveAsync(ParametroChave.JwtPublicKey);
            return parametro.Valor;
        }

        public async Task<string> ObterTempoExpiracaoJwtAsync()
        {
            var parametro = await _parametroRepository.ObterParametroPorChaveAsync(ParametroChave.JwtExpirationMinutes);
            return parametro.Valor;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
