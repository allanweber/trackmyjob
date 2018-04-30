using AutoMapper;
using TrackMyJob.Domain.CommandHandlers.Commands.Assignment;
using TrackMyJob.Domain.CommandHandlers.Commands.Project;
using TrackMyJob.Domain.Entities;

namespace TrackMyJob.Infrastructure.Mappers
{
    public class DtoToEntities: Profile
    {
        public DtoToEntities()
        {
            this.CreateMap<ProjectInsertCommand, Project>();
            this.CreateMap<ProjectUpdateCommand, Project>();

            this.CreateMap<AssignmentInsertCommand, Assignment>();
            this.CreateMap<AssignmentUpdateCommand, Assignment>();
        }
    }
}
