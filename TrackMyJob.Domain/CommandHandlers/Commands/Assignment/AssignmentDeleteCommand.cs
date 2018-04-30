using MediatR;
using TrackMyJob.Framework.CommandHandlers;
using TrackMyJob.Framework.Entities;

namespace TrackMyJob.Domain.CommandHandlers.Commands.Assignment
{
    public class AssignmentDeleteCommand : BaseEntity, IRequest<ICommandResult>
    {
    }
}
