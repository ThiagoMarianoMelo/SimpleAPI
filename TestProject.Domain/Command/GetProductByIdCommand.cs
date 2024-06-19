using MediatR;
using TestProject.Domain.Entities;

namespace TestProject.Domain.Command
{
    public class GetProductByIdCommand : IRequest<ResponseWithData<Product>>
    {
        public Guid Id { get; set; }
    }
}
