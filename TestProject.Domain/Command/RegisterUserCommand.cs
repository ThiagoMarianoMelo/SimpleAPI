using MediatR;

namespace TestProject.Domain.Command
{
    public class RegisterUserCommand : IRequest<Response>
    {

        public string? Email { get; set; } 
        public string? Password { get; set; } 
        public string? Username { get; set;}
        public string? ExtraInformation { get; set; }
    }
}
