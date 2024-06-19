using MediatR;

namespace TestProject.Domain.Command
{
    public class LoginUserCommand : IRequest<ResponseWithData<string>>
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
