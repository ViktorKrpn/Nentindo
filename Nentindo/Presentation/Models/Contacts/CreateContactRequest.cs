using Nentindo.Core.Domain.Contacts;

namespace Nentindo.Presentation.Models.Contacts
{
    public class CreateContactRequest
    {
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int? SupplierId { get; set; }
        public int? SubcontractorId { get; set; }
    }
}
