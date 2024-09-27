using Nentindo.Core.Domain.Users;

namespace Nentindo.Core.Domain.Companies
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsParentCompany { get; set; }
        public virtual List<User> Users { get; set; }
    }
}
