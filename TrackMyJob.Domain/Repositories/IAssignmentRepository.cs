using System.Collections.Generic;
using System.Threading.Tasks;
using TrackMyJob.Domain.Entities;
using TrackMyJob.Framework.Repositories;

namespace TrackMyJob.Domain.Repositories
{
    public interface IAssignmentRepository: IRepository<Assignment>
    {
        Task<IEnumerable<Assignment>> GetAllByProject(int projectId);

        Task DoneAssignment(int assignmentId);

        Task<long> CountByProject(int projectId);

        Task<long> CountCompletedByProject(int projectId);

        Task<long> CountLateByProject(int projectId);
    }
}
