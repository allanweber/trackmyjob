using TrackMyJob.Framework.CommandHandlers;
using MediatR;

namespace TrackMyJob.Domain.CommandHandlers.Commands.Project
{
    public class ProjectInsertCommand: IRequest<ICommandResult>
    {
        public string Name { get; set; }
    }
}
