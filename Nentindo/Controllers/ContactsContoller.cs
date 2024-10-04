using Microsoft.AspNetCore.Mvc;
using Nentindo.Core.Domain.Contacts;
using Nentindo.Models;
using Nentindo.Services.Contacts;

namespace Nentindo.Controllers
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

        [HttpGet("GetContacts")]
        public async Task<IActionResult> GetContacts()
        {
            try
            {
                var contacts = await _contactService.GetContacts();
                var response = new GenericResponse<List<Contact>> { Result = contacts };
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
