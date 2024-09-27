using Nentindo.Core.Domain.Companies;

namespace Nentindo.Core.Domain.Users
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHashed { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public virtual List<Role> Roles { get; set; } = [];
    }
}
