using IsubuBurada.WebUi.Models;
using IsubuBurada.WebUi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IsubuBurada.WebUi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IKatalogService _katalogService;

        public HomeController(ILogger<HomeController> logger, 
            IKatalogService katalogService)
        {
            _logger = logger;
            _katalogService = katalogService;
        }

        public async Task<IActionResult> Index()
        {
            
            return View();
        }

        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
