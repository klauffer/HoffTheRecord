using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Hasselhoffing
{
    [Route("api/[controller]")]
    [ApiController]
    public class HasselhoffingController : ControllerBase
    {
        private readonly ILogger<HasselhoffingController> _logger;
        private readonly IMediator _mediator;

        public HasselhoffingController(ILogger<HasselhoffingController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> SubmitHoffing(HasslehoffACoworkerRequest hasslehoffAPersonRequest)
        {
            var command = hasslehoffAPersonRequest.ToCommand();
            var HasslehoffingId = await _mediator.Send(command);
            //return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
            return CreatedAtAction(null, new { id = HasslehoffingId }, HasslehoffingId);
        }
    }
}
