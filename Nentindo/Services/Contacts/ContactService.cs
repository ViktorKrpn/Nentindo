using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Nentindo.Core.Domain.Contacts;
using Nentindo.Data;
using Nentindo.Presentation.Models;
using Nentindo.Presentation.Models.Contacts;
using System.Linq.Expressions;

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
        public class GenericSearchRequest<T>
        {
            public int Id { get; set; }
            public string SearchTerm { get; set; }
        }
        public async Task<List<Contact>> GetContacts(Expression<Func<Contact, bool>> filter)
        {
            return await _db.Contacts.Where(filter).ToListAsync();
        }


        public async Task<GenericResponse<Contact>> CreateContact(CreateContactRequest request)
        {
            var response = new GenericResponse<Contact>();

            var existingContact = (await GetContacts(c => c.Email == request.Email))
                .FirstOrDefault();

            if(existingContact != null)
            {
                response.AddError($"We alredy have a contact with {request.Email} email address");
                return response;
            }

            var contact = new Contact
            {
                Salutation = request.Salutation,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                SubcontractorId = request.SubcontractorId,
                SupplierId = request.SupplierId,
            };

            await _db.Contacts.AddAsync(contact);
            await _db.SaveChangesAsync();

            var createdContact = (await GetContacts(c => c.Email == request.Email))
                .FirstOrDefault();

            response.Result = createdContact;

            return response;
        }
    }
}
