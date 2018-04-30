using TrackMyJob.Domain.Entities;
using TrackMyJob.Domain.Repositories;
using TrackMyJob.Framework.Repositories;

namespace TrackMyJob.Infrastructure.Repositories
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(PrincipalDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
