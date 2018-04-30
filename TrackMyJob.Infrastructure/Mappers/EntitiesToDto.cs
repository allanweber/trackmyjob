using AutoMapper;
using TrackMyJob.Domain.Dtos;
using TrackMyJob.Domain.Entities;

namespace TrackMyJob.Infrastructure.Mappers
{
    public class EntitiesToDto: Profile
    {
        public EntitiesToDto()
        {
            this.CreateMap<Project, ProjectDto>();

            this.CreateMap<Assignment, AssignmentDto>();
        }
    }
}
