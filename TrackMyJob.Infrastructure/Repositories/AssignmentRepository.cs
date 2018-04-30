using System.Collections.Generic;
using System.Threading.Tasks;
using TrackMyJob.Domain.Entities;
using TrackMyJob.Domain.Repositories;
using TrackMyJob.Domain.Specifications;
using TrackMyJob.Framework.Repositories;

namespace TrackMyJob.Infrastructure.Repositories
{
    public class AssignmentRepository : Repository<Assignment>, IAssignmentRepository
    {
        public AssignmentRepository(PrincipalDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<long> CountByProject(int projectId)
        {
            AssignmentsByProjectId spec = new AssignmentsByProjectId(projectId);

            return await this.CountAsync(spec);
        }

        public async Task<long> CountCompletedByProject(int projectId)
        {
            AssignmentsDoneByProjectId spec = new AssignmentsDoneByProjectId(projectId);

            return await this.CountAsync(spec);
        }

        public async Task<long> CountLateByProject(int projectId)
        {
            AssignmentsLateByProjectId spec = new AssignmentsLateByProjectId(projectId);

            return await this.CountAsync(spec);
        }

        public async Task DoneAssignment(int assignmentId)
        {
            var entity = await this.GetAsync(assignmentId);

            entity.Done();

            await this.UpdateAsync(entity);

            await this.CommitAsync();
        }

        public async Task<IEnumerable<Assignment>> GetAllByProject(int projectId)
        {
            AssignmentsByProjectId spec = new AssignmentsByProjectId(projectId);

            return await this.QueryAsync(spec);
        }
    }
}
