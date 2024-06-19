using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestProject.Authorizations;
using TestProject.Domain.Command;

namespace TestProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator Mediator;

        public ProductController(IMediator mediator)
        {
           Mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetProductByIdCommand request, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(request, cancellationToken);

            return result.Success ? Ok(result) : BadRequest(result);
        }

        [AdminAuthorization]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductCommand request, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(request, cancellationToken);

            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
