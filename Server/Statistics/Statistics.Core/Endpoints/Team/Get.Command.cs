using MediatR;
using Statistics.Core.Endoints.Team.Models;

namespace Statistics.Core.Endoints.Team
{
    public class GetCommand : IRequest<TeamModel>
    {
        public int Id { get; set; }
    }
}
