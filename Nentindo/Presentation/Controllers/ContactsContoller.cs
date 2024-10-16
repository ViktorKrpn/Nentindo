﻿using Microsoft.AspNetCore.Mvc;
using Nentindo.Core.Domain.Contacts;
using Nentindo.Presentation.Models;
using Nentindo.Presentation.Models.Contacts;
using Nentindo.Services.Contacts;

namespace Nentindo.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        IContactService _contactService;
        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            try
            {
                var contacts = await _contactService.GetContacts(contact => true);
                var response = new GenericResponse<List<Contact>> { Result = contacts };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var contacts = await _contactService.GetContacts(contact => contact.Id == id);
            var response = new GenericResponse<Contact> { Result = contacts.FirstOrDefault() };
            return Ok(response);
        }




        [HttpPost("create")]
        public async Task<IActionResult> CreateContact(CreateContactRequest request)
        {
            try
            {
                var response = await _contactService.CreateContact(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("login")]
        public async Task<IActionResult> Login()
        {
            return Ok();
        }
    }
}
