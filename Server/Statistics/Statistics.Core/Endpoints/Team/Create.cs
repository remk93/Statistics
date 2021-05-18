using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Statistics.DataStorage.DataContext;
using System.Threading;
using System.Threading.Tasks;

namespace Statistics.Core.Endoints.Team
{
    public class CreateHandler : IRequestHandler<CreateCommand, Unit>
    {
        private readonly IDbContextFactory<EntitiesContext> _contextFactory;
        private readonly IMapper _mapper;

        public CreateHandler(
            IDbContextFactory<EntitiesContext> contextFactory,
            IMapper mapper)
        {
            _contextFactory = contextFactory;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            using var context = _contextFactory.CreateDbContext();

            var entity = _mapper.Map<DataStorage.Entities.Team>(request);

            await context.AddAsync(entity, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
