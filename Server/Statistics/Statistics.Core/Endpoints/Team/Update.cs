using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Statistics.Core.Exceptions;
using Statistics.DataStorage.DataContext;
using System.Threading;
using System.Threading.Tasks;

namespace Statistics.Core.Endoints.Team
{
    public class UpdateHandler : IRequestHandler<UpdateCommand, Unit>
    {
        private readonly IDbContextFactory<EntitiesContext> _contextFactory;
        private readonly IMapper _mapper;

        public UpdateHandler(
            IDbContextFactory<EntitiesContext> contextFactory,
            IMapper mapper)
        {
            _contextFactory = contextFactory;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            using var context = _contextFactory.CreateDbContext();

            var entity = await context.Teams.FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken) ??
                throw new NotFoundException($"Team/{request.Id} was not found.");

            _mapper.Map(request, entity);

            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
