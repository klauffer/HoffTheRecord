using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Hasselhoffing
{
    [Route("api/[controller]")]
    [ApiController]
    public class HasselhoffController : ControllerBase
    {
        private readonly ILogger<HasselhoffController> _logger;
        private readonly IMediator _mediator;

        public HasselhoffController(ILogger<HasselhoffController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> SubmitHoffing(HasslehoffACoworkerRequest hasslehoffAPersonRequest, CancellationToken cancellationToken)
        {
            var command = hasslehoffAPersonRequest.ToCommand();
            var HasslehoffingId = await _mediator.Send(command, cancellationToken);
            //return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
            return CreatedAtAction(null, new { id = HasslehoffingId }, HasslehoffingId);
        }
    }
}
