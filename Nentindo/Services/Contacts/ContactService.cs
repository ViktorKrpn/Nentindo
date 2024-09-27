using Microsoft.EntityFrameworkCore;
using Nentindo.Core.Domain.Contacts;
using Nentindo.Data;

namespace Nentindo.Services.Contacts
{
    public class ContactService: IContactService
    {
        DatabaseContext _db;

        public ContactService(DatabaseContext db)
        {
            _db = db;
        }
        public async Task CreateContact(Contact contact)
        {
            await _db.Contacts.AddAsync(contact);  
            await _db.SaveChangesAsync();
        }
        public async Task<List<Contact>> GetContacts()
        {
            return await _db.Contacts.ToListAsync();
        }
    }
}
