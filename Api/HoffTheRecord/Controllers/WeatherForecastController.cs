using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HoffTheRecord.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthCheckController : ControllerBase
    {


        private readonly ILogger<HealthCheckController> _logger;
        private readonly IMediator _mediator;

        public HealthCheckController(ILogger<HealthCheckController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}