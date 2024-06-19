using Microsoft.AspNetCore.Http;
using TestProject.Domain.Interfaces;

namespace TestProject.Application
{
    public class AuthUser : IAuthUser
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;

        public AuthUser(IHttpContextAccessor context) => SetAuthUserData(context);

        private void SetAuthUserData(IHttpContextAccessor context)
        {
            Id = Guid.Parse(context.HttpContext?.User.FindFirst("UserID")?.Value ?? string.Empty);
            Email = context.HttpContext?.User.FindFirst("Email")?.Value ?? string.Empty;
        }
    }
}
