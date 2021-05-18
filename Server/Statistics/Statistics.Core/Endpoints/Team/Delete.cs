using MediatR;
using Microsoft.EntityFrameworkCore;
using Statistics.Core.Exceptions;
using Statistics.DataStorage.DataContext;
using System.Threading;
using System.Threading.Tasks;

namespace Statistics.Core.Endoints.Team
{
    public class DeleteHandler : IRequestHandler<DeleteCommand, Unit>
    {
        private readonly IDbContextFactory<EntitiesContext> _contextFactory;

        public DeleteHandler(IDbContextFactory<EntitiesContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<Unit> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            using var context = _contextFactory.CreateDbContext();

            var entity = await context.Teams
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken) ??
                    throw new NotFoundException($"Team/{request.Id} was not found.");

            context.Remove(entity);
            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}