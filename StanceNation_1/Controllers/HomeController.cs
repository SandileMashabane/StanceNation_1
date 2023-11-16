using Microsoft.AspNetCore.Mvc;
using StanceNation_1.Models;
using System.Diagnostics;
using StanceNation_1.Data;
using StanceNation_1.Models;

namespace StanceNation_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly dbContext _context;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult UpcomingEvents()
        {
            return View(_context.StanceEvents.ToList());
        }
        public ActionResult Events(EventsModel events)
        {
            byte[] bytes = null;
            if (events.ImageFile != null )
            {
                using (Stream Fs = events.ImageFile.OpenReadStream())
                {
                    using (BinaryReader br = new BinaryReader(Fs)) 
                    {
                        bytes = br.ReadBytes((Int32)Fs.Length);
                    }
                }
                events.eventImage = Convert.ToBase64String(bytes, 0 , bytes.Length);
                _context.StanceEvents.Add(events);
                _context.SaveChanges();
                return View("UpcomingEvents","Home");
            }
            return View();
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