using CantinaFacil.Infrastructure.Data.Context;
using CantinaFacil.Infrastructure.Data.Extensions;
using CantinaFacil.Shared.Kernel.Data;
using CantinaFacil.Shared.Kernel.Mediator;

namespace CantinaFacil.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private readonly IMediatorHandler _mediatorHandler;

        public UnitOfWork(DataContext dataContext, IMediatorHandler mediatorHandler)
        {
            _context = dataContext;
            _mediatorHandler = mediatorHandler;
        }

        public async Task<bool> CommitAsync()
        {
            var success = await _context.SaveChangesAsync() > 0;

            if (success)
                await _mediatorHandler.PublishEvents(_context);

            return true;
        }
    }
}
