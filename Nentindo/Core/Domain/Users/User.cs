
namespace Nentindo.Core.Domain.Users
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHashed { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual List<Role> Roles { get; set; } = [];
    }
}
