using InfoTech.Application.Commands;
using InfoTech.Application.Queries;
using InfoTech.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InfoTech.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController(ISender sender) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> AddLoginAsync([FromBody] LoginEntity login)
        {
            var result = await sender.Send(new AddLoginCommand(login));
            return Ok(result);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetLoginByIdAsync()
        {
            var result = await sender.Send(new GetAllLoginsQuery());
            return Ok(result);
        }

        [HttpGet("{employeeId}")]
        public async Task<IActionResult> UpdateLoginsAsync([FromRoute]Guid employeeId)
        {
            var result = await sender.Send(new GetLoginByIdQuery(employeeId));
            return Ok(result);
        }

        [HttpPut("{employeeId}")]
        public async Task<IActionResult> GetAllLoginsAsync([FromRoute] Guid employeeId, [FromBody] LoginEntity login)
        {
            var result = await sender.Send(new UpdateLoginCommand(employeeId, login));
            return Ok(result);
        }

        [HttpDelete("{employeeId}")]
        public async Task<IActionResult> DeleteLoginAsync([FromRoute] Guid employeeId)
        {
            var result = await sender.Send(new DeleteLoginCommand(employeeId));
            return Ok(result);
        }
    }
}
