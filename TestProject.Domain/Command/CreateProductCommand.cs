using MediatR;

namespace TestProject.Domain.Command
{
    public class CreateProductCommand : IRequest<Response>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
