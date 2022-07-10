using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRLeaveManagement.Application.DTOs.LeaveType;
using HRLeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HRLeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRLeaveManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/LeaveTypes
        [HttpGet]
        public async Task<ActionResult<List<LeaveTypeDto>>> Get()
        {
            var leaveTypesList = await _mediator.Send(new GetLeaveTypeListQuery());
            return Ok(leaveTypesList);
        }

        // GET: api/LeaveTypes/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<LeaveTypeDto>> Get(int id)
        {
            var leaveType = await _mediator.Send(new GetLeaveTypeDetailQuery {  Id = id });
            return Ok(leaveType);
        }

        // POST: api/LeaveTypes
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateLeaveTypeDto leaveTypeDto)
        {
            var command = new CreateLeaveTypeCommand{ LeaveTypeDto = leaveTypeDto};
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        // PUT: api/LeaveTypes
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] LeaveTypeDto leaveTypeDto)
        {
            var command = new UpdateLeaveTypeCommand { LeaveTypeDto = leaveTypeDto };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE: api/LeaveTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveTypeCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
