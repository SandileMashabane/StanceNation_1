using Microsoft.AspNetCore.Mvc;
using StanceNation_1.Models;
using System.Diagnostics;

namespace StanceNation_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Event_Coverage()
        {
            return View();
        }
        public IActionResult Car_Features()
        {
            return View();
        }
        public IActionResult Upcoming_Events()
        {
            return View();
        }
        public IActionResult Around_The_Web()
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