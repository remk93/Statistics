using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Statistics.Core.Exceptions;
using Statistics.Core.Endoints.Team.Models;
using Statistics.DataStorage.DataContext;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Statistics.Core.Endoints.Team
{
    public class GetHandler : IRequestHandler<GetCommand, TeamModel>
    {
        private readonly IDbContextFactory<EntitiesContext> _contextFactory;
        private readonly IMapper _mapper;

        public GetHandler(
            IDbContextFactory<EntitiesContext> contextFactory,
            IMapper mapper)
        {
            _contextFactory = contextFactory;
            _mapper = mapper;
        }

        public async Task<TeamModel> Handle(GetCommand request, CancellationToken cancellationToken)
        {
            using var context = _contextFactory.CreateDbContext();

            var model = await context.Teams
                .AsNoTracking()
                .Where(_ => _.Id == request.Id)
                .ProjectTo<TeamModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken) ??
                    throw new NotFoundException($"Team/{request.Id} was not found.");

            return model;
        }
    }
}