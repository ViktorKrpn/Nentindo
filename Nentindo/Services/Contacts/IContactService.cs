﻿using Nentindo.Core.Domain.Contacts;
using Nentindo.Presentation.Models;
using Nentindo.Presentation.Models.Contacts;
using System.Linq.Expressions;

namespace Nentindo.Services.Contacts
{
    public interface IContactService
    {
        public Task<List<Contact>> GetContacts(Expression<Func<Contact, bool>> filter);
        public Task<GenericResponse<Contact>> CreateContact(CreateContactRequest request);
        public Task<Dictionary<string, bool>> CheckIfEmailsExist(List<string> emails);
        public Task<GenericResponse<string>> CreateBatchContacts(List<CreateContactRequest> contacts);
    }
}
