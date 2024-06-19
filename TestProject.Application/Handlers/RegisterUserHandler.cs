using MediatR;
using Microsoft.AspNetCore.Identity;
using TestProject.Application.Utilities;
using TestProject.Domain.Command;
using TestProject.Domain.Entities;
using TestProject.Domain.Roles;

namespace TestProject.Application.Handlers
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, Response>
    {
        private readonly UserManager<User> UserManager;

        public RegisterUserHandler(UserManager<User> userManager)
        {
            UserManager = userManager;
        }

        public async Task<Response> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
                return new ResponseWithData<Guid>{ Success = false, Message = "Email e Senha são obrigatórios para cadastro." };

            var userByEmail = await UserManager.FindByEmailAsync(request.Email);

            if(userByEmail != null)
                return new ResponseWithData<Guid> { Success = false, Message = "Email já cadastrado." };

            var user = new User { Email = request.Email, UserName = request.Username, 
                ExtraInformation = request.ExtraInformation };

            var userCreatedResult = await UserManager.CreateAsync(user, request.Password);

            if(!userCreatedResult.Succeeded)
                return new ResponseWithData<Guid>
                {
                    Success = false,
                    Message = userCreatedResult.Errors?.FirstOrDefault()?.Description ?? ""
                };

            await UserManager.AddToRoleAsync(user, RolesEnum.Admin.GetStringValue());

            return new Response() { Success = true, Message = "Usúario criado com sucesso." };
        }
    }
}
