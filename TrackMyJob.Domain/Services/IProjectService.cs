using System.Threading.Tasks;
using TrackMyJob.Domain.Dtos;
using TrackMyJob.Framework.Services;

namespace TrackMyJob.Domain.Services
{
    public interface IProjectService: IService
    {
        Task<ProjectStatusDto> GetProjectStatus(int projectId);
    }
}
