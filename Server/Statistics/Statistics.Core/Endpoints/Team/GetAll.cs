using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Statistics.Core.Models;
using Statistics.Core.Endoints.Team.Models;
using Statistics.DataStorage.DataContext;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Statistics.Core.Extensions;

namespace Statistics.Core.Endoints.Team
{
    public class GetByQueryHandler : IRequestHandler<GetAllCommand, PagedResult<TeamModel>>
    {
        private readonly IDbContextFactory<EntitiesContext> _contextFactory;
        private readonly IMapper _mapper;

        public GetByQueryHandler(
            IDbContextFactory<EntitiesContext> contextFactory,
            IMapper mapper)
        {
            _contextFactory = contextFactory;
            _mapper = mapper;
        }

        public async Task<PagedResult<TeamModel>> Handle(GetAllCommand request, CancellationToken cancellationToken)
        {
            using var context = _contextFactory.CreateDbContext();

            var models = await context.Teams
                .AsNoTracking()
                .Where(GetAllQuery.GetExpression(request.SearchByText))
                .SortExpression(request.SortBy, request.IsAscending)
                .Paginate(request.PageNumber, request.PageSize)
                .ProjectTo<TeamModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new PagedResult<TeamModel>(context.Teams.Count(), models);
        }
    }
}