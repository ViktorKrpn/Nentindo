using Nentindo.Database.Models;

namespace Nentindo.Core.Domain.Contacts
{
    public class Contact
    {
        public int Id { get; set; }
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
        public int? SubcontractorId { get; set; }
        public virtual Subcontractor Subcontractor { get; set; }
        public List<Subscribtion> Subscribtions { get; set; } = [];

    }
}
