using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestProject.Domain.Command;

namespace TestProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IMediator Mediator;
        public UserController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpPost]
        [Route("/Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand request, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(request, cancellationToken);

            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost]
        [Route("/Register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand request, CancellationToken cancellationToken)
        {

            var result = await Mediator.Send(request, cancellationToken);

            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
