using MediatR;
using Statistics.Core.Models;
using Statistics.Core.Endoints.Team.Models;
using Statistics.Core.Queries;

namespace Statistics.Core.Endoints.Team
{
    public record GetAllCommand : PagedFilter, IRequest<PagedResult<TeamModel>>
    {
    }
}
