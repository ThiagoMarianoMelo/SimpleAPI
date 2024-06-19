using MediatR;
using Microsoft.AspNetCore.Identity;
using TestProject.Domain.Command;
using TestProject.Domain.Entities;
using TestProject.Domain.Interfaces.Services;

namespace TestProject.Application.Handlers
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, ResponseWithData<string>>
    {
        private readonly UserManager<User> userManager;
        private readonly ITokenService TokenService;

        public LoginUserHandler(UserManager<User> userManager, ITokenService tokenService)
        {
            this.userManager = userManager;
            TokenService = tokenService;
        }

        public async Task<ResponseWithData<string>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            if(request.Email == null || request.Password == null)
                return new ResponseWithData<string> { Success = false, Message = "Email e senha necessário para realizar login" };

            var user = await userManager.FindByEmailAsync(request.Email);

            if (user == null)
                return new ResponseWithData<string> { Success = false, Message = "Login Inválido" };

            var resultCheckPassword = await userManager.CheckPasswordAsync(user, request.Password);

            if (!resultCheckPassword)
                return new ResponseWithData<string> { Success = false, Message = "Login Inválido" };

            var token = await TokenService.GenerateTokenByUser(user);

            return new ResponseWithData<string>() { Data = token, Success = true };
        }
    }
}
