using HR.LeaveManagment.Application.DTOs.LeaveAllocation;
using HR.LeaveManagment.Application.Features.LeaveAllocation.Requestes.Commands;
using HR.LeaveManagment.Application.Features.LeaveAllocation.Requestes.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.LeaveManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveAllocationController : ControllerBase
    {
        public IMediator _mediator { get; }

        public LeaveAllocationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<LeaveAllocation>
        [HttpGet]
        public async Task<ActionResult<List<LeaveAllocationDto>>> Get()
        {
            var request = new GetLeaveAllocationListRequest();
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        // GET api/<LeaveAllocation>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveAllocationDto>> Get(int id)
        {
            var request = new GetLeaveAllocationRequest { Id = id };
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        // POST api/<LeaveAllocation>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]CreateLeaveAllocationDto value)
        {
            var request = new CreateLeaveAllocationCommand { LeaveAllocationDto = value };
            var response = await _mediator.Send(request);
            return NoContent();
        }

        // PUT api/<LeaveAllocation>
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] UpdateLeaveAllocationDto value)
        {
            var command = new UpdateLeaveAllocationCommand();
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<LeaveAllocation>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveAllocationCommand() { Id = id};
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
