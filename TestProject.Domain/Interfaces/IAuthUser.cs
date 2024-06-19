namespace TestProject.Domain.Interfaces
{
    public interface IAuthUser
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
    }
}
