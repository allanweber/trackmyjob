using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrackMyJob.Domain.CommandHandlers.Commands.Assignment;
using TrackMyJob.Domain.Dtos;
using TrackMyJob.Domain.Entities;
using TrackMyJob.Domain.Repositories;
using TrackMyJob.Framework.Constants;
using TrackMyJob.Framework.Controllers;

namespace TrackMyJob.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[Controller]")]
    [EnableCors(AppConstants.ALLOWALLHEADERS)]
    public class AssignmentController :
        BaseCrudController<
            IAssignmentRepository,
            Assignment,
            AssignmentInsertCommand,
            AssignmentUpdateCommand,
            AssignmentDeleteCommand,
            AssignmentDto>
    {
        public AssignmentController(IMapper mapper, IMediator mediator, IAssignmentRepository assignmentRepository)
            : base(mapper, mediator, assignmentRepository)
        {
            AssignmentRepository = assignmentRepository;
        }

        public IAssignmentRepository AssignmentRepository { get; }

        [HttpPut]
        [Route("{assignmentId:int}/done")]
        public async Task<IActionResult> Done(int assignmentId)
        {
            await this.AssignmentRepository.DoneAssignment(assignmentId);

            return Ok();
        }
    }
}