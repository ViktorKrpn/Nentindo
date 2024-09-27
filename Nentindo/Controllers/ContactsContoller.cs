using Microsoft.AspNetCore.Mvc;
using Nentindo.Services.Contacts;

namespace Nentindo.Controllers
{
    public class ContactsContoller : Controller
    {
        IContactService _contactService;
        public ContactsContoller(IContactService contactService)
        {
            _contactService = contactService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {

        }
    }
}
