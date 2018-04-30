using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TrackMyJob.Domain.CommandHandlers.Commands.Project;
using TrackMyJob.Domain.Dtos;
using TrackMyJob.Domain.Entities;
using TrackMyJob.Domain.Repositories;
using TrackMyJob.Domain.Services;
using TrackMyJob.Framework.Constants;
using TrackMyJob.Framework.Controllers;

namespace TrackMyJob.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[Controller]")]
    [EnableCors(AppConstants.ALLOWALLHEADERS)]
    public class ProjectController :
        BaseCrudController<
            IProjectRepository,
            Project,
            ProjectInsertCommand,
            ProjectUpdateCommand,
            ProjectDeleteCommand,
            ProjectDto>
    {
        public ProjectController(IMapper mapper, IMediator mediator, 
            IProjectRepository projectRepository, IProjectService projectService)
            : base(mapper, mediator, projectRepository)
        {
            this.ProjectService = projectService;
        }

        public IProjectService ProjectService { get; }

        [HttpGet]
        [Route("{projectId:int}/status")]
        public async Task<IActionResult> Status(int projectId)
        {
            var dto = await this.ProjectService.GetProjectStatus(projectId);

            return Ok(dto);
        }
    }
}