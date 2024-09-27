using Microsoft.AspNetCore.Mvc;
using Nentindo.Data;
using Nentindo.Models;
using System.Diagnostics;

namespace Nentindo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
