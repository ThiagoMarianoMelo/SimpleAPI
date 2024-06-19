using Microsoft.AspNetCore.Authorization;
using TestProject.Application.Utilities;
using TestProject.Domain.Roles;

namespace TestProject.Authorizations
{
    public class AdminAuthorization : AuthorizeAttribute
    {
        public AdminAuthorization()
        {
            Roles = RolesEnum.Admin.GetStringValue();
        }
    }
}
