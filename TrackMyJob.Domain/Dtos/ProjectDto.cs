using TrackMyJob.Framework.Dtos;

namespace TrackMyJob.Domain.Dtos
{
    public class ProjectDto: IDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string PathName { get; set; }
    }
}
