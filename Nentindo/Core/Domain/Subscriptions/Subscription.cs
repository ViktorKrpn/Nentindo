using Nentindo.Core.Domain.Companies;
using Nentindo.Core.Domain.Contacts;

namespace Nentindo.Core.Domain.Subscriptions
{
    public class Subscription
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public virtual Contact Contact { get; set; }
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

    }
}
