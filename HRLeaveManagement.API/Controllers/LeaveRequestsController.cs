using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRLeaveManagement.Application.DTOs.LeaveRequest;
using HRLeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HRLeaveManagement.Application.Features.LeaveRequests.Requests.Queries;
using HRLeaveManagement.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRLeaveManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LeaveRequestsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/LeaveRequests
        [HttpGet]
        public async Task<ActionResult<List<LeaveRequestListDto>>> Get()
        {
            var result = await _mediator.Send(new GetLeaveRequestListQuery());
            return Ok(result);
        }

        // GET: api/LeaveRequests/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<LeaveRequestDto>> Get(int id)
        {
            var command = new GetLeaveRequestDetailQuery { Id = id };
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // POST: api/LeaveRequests
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateLeaveRequestDto leaveRequestDto)
        {
            var command = new CreateLeaveRequestCommand { LeaveRequestDto = leaveRequestDto };
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // PUT: api/LeaveRequests/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateLeaveRequestDto updateLeaveDto)
        {
            var command = new UpdateLeaveRequestCommand { Id = id, LeaveRequestDto = updateLeaveDto };
            await _mediator.Send(command);
            return NoContent();
        }

        // PUT: api/LeaveRequests/changeapproval/5
        [HttpPut("changeapproval/{id}")]
        public async Task<ActionResult> ChangeApproval(int id, [FromBody] ChangeLeaveRequestApprovalDto changeApprovalLeaveDto)
        {
            var command = new UpdateLeaveRequestCommand { Id = id, ChangeLeaveRequestApprovalDto = changeApprovalLeaveDto };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE: api/LeaveRequests/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveRequestCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
