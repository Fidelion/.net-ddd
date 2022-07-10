using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRLeaveManagement.Application.DTOs.LeaveAllocation;
using HRLeaveManagement.Application.Features.LeaveAllocations.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRLeaveManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveAllocationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveAllocationsController(IMediator mediator) {
            _mediator = mediator;
        }

        // GET: api/LeaveAllocations
        [HttpGet]
        public async Task<ActionResult<List<LeaveAllocationDto>>> Get()
        {
            var result = await _mediator.Send(new GetLeaveAllocationListQuery());
            return Ok(result);
        }

        // GET: api/LeaveAllocations/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/LeaveAllocations
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/LeaveAllocations/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/LeaveAllocations/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
