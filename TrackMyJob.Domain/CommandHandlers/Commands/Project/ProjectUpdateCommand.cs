using MediatR;
using TrackMyJob.Framework.CommandHandlers;
using TrackMyJob.Framework.Entities;

namespace TrackMyJob.Domain.CommandHandlers.Commands.Project
{
    public class ProjectUpdateCommand: BaseEntity, IRequest<ICommandResult>
    {
        public string Name { get; set; }
    }
}
