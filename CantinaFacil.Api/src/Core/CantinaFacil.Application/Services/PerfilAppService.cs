using AutoMapper;
using MediatR;
using CantinaFacil.Shared.Kernel.Application;
using CantinaFacil.Shared.Kernel.Data;
using CantinaFacil.Shared.Kernel.Domain.Events;
using CantinaFacil.Shared.Kernel.Mediator;
using CantinaFacil.Application.Services.Interfaces;
using CantinaFacil.Domain.Aggregates.Perfis.Repository;
using CantinaFacil.Application.ViewModels.Perfil;

namespace CantinaFacil.Application.Services
{
    public class PerfilAppService : ApplicationService, IPerfilAppService
    {
        private readonly IPerfilRepository _perfilRepository;
        private readonly IMapper _mapper;

        public PerfilAppService
        (
            IUnitOfWork unitOfWork,
            IMediatorHandler mediator,
            INotificationHandler<DomainNotificationEvent> notifications,
            IPerfilRepository perfilRepository,
            IMapper mapper
        ) : base(unitOfWork, mediator, notifications)
        {
            _perfilRepository = perfilRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ObterPerfilViewModel>> ObterTodosAsync()
        {
            return _mapper.Map<IEnumerable<ObterPerfilViewModel>>(await _perfilRepository.GetAllAsync());
        }

        public void Dispose()
        {
            _perfilRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
