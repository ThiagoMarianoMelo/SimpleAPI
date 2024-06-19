using Microsoft.AspNetCore.Identity;

namespace TestProject.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string? ExtraInformation { get; set; }
    }
}
