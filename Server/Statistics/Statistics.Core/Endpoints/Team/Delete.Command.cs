using MediatR;

namespace Statistics.Core.Endoints.Team
{
    public class DeleteCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
