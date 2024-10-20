using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Nentindo.Core.Domain.Contacts;
using Nentindo.Core.Domain.Users;
using Nentindo.Data;
using Nentindo.Presentation.Controllers;
using Nentindo.Presentation.Models;
using Nentindo.Presentation.Models.Contacts;
using System.Linq.Expressions;
using System.Security.Claims;

namespace Nentindo.Services.Contacts
{
    public class ContactService: NentindoServiceBase, IContactService
    {
        public ContactService(DatabaseContext db, IHttpContextAccessor httpContextAccessor): base(db, httpContextAccessor)
        {

        }

        public async Task CreateContact(Contact contact)
        {
            await Db.Contacts.AddAsync(contact);  
            await Db.SaveChangesAsync();
        }

        public async Task<List<Contact>> GetContacts(Expression<Func<Contact, bool>> filter)
        {
            return await Db.Contacts.Where(filter).ToListAsync();
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

            await Db.Contacts.AddAsync(contact);
            await Db.SaveChangesAsync();

            var createdContact = (await GetContacts(c => c.Email == request.Email))
                .FirstOrDefault();

            response.Result = createdContact;

            return response;
        }

        public async Task<GenericResponse<string>> CreateBatchContacts(List<CreateContactRequest> contacts)
        {
            var response = new GenericResponse<string>();
            var amountInserted = 0;
            var amountDuplicates = 0;


            foreach (var contact in contacts)
            {
                var res = await CreateContact(contact);
                if (res.IsSuccessful)
                {
                    amountInserted++;
                } else
                {
                    amountDuplicates++;
                }
            }
            response.Result = $"We have inserted {amountInserted} contacts. We have ingonered {amountDuplicates} contacts, because they are duplicates";

            return response;
        }



        public async Task<Dictionary<string, bool>> CheckIfEmailsExist(List<string> emails)
        {
            var existingEmails = await Db.Contacts
                .Where(c => emails.Contains(c.Email))
                .Select(c => c.Email)
                .ToListAsync();

            var dictionary = emails.Distinct().ToDictionary(email => email, existingEmails.Contains);

            return dictionary;
        }
    }

}
