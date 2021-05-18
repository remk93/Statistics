using MediatR;
using Statistics.Core.Endoints.Team.Models;

namespace Statistics.Core.Endoints.Team
{
    public class CreateCommand : TeamModel, IRequest<Unit>
    {
    }
}
