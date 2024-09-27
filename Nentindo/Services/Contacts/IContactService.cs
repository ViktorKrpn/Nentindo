using Nentindo.Core.Domain.Contacts;
using Nentindo.Models;

namespace Nentindo.Services.Contacts
{
    public interface IContactService
    {
        public Task<List<Contact>> GetContacts();

    }
}
