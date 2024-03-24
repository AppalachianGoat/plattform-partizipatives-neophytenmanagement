namespace plattform_partizipatives_neophytenmanagement.Services
{
    public class CreateUserDto
    {
        public string Role { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public interface IUserService
    {

    }
}