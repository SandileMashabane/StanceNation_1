using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StanceNation_1.Data;
using StanceNation_1.Models;

namespace StanceNation_1.Controllers
{
    public class EventsModelsController : Controller
    {
        private readonly dbContext _context;

        public EventsModelsController(dbContext context)
        {
            _context = context;
        }
        public IActionResult UpcomingEvents()
        {
            return View(_context.StanceEvents.ToList());
        }
        public IActionResult UpcomingEventsView()
        {
            return View(_context.StanceEvents.ToList());
        }
        public ActionResult Events(EventsModel events)
        {
            byte[] bytes = null;

            if (events.ImageFile != null)
            {
                using (Stream Fs = events.ImageFile.OpenReadStream())
                {
                    using (BinaryReader br = new BinaryReader(Fs))
                    {
                        bytes = br.ReadBytes((Int32)Fs.Length);
                    }
                }
                events.eventImage = Convert.ToBase64String(bytes, 0, bytes.Length);
                _context.StanceEvents.Add(events);
                _context.SaveChanges();
                return RedirectToAction(nameof(UpcomingEvents));
            }
            return View();
        }

       

        // GET: EventsModels/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.StanceEvents == null)
            {
                return NotFound();
            }

            var eventsModel = await _context.StanceEvents
                .FirstOrDefaultAsync(m => m.eventName == id);
            if (eventsModel == null)
            {
                return NotFound();
            }

            return View(eventsModel);
        }

        
       

        // GET: EventsModels/Edit/5
       

       

        // GET: EventsModels/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.StanceEvents == null)
            {
                return NotFound();
            }

            var eventsModel = await _context.StanceEvents
                .FirstOrDefaultAsync(m => m.eventName == id);
            if (eventsModel == null)
            {
                return NotFound();
            }

            return View(eventsModel);
        }

        // POST: EventsModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.StanceEvents == null)
            {
                return Problem("Entity set 'dbContext.StanceEvents'  is null.");
            }
            var eventsModel = await _context.StanceEvents.FindAsync(id);
            if (eventsModel != null)
            {
                _context.StanceEvents.Remove(eventsModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(UpcomingEvents));
        }

        private bool EventsModelExists(string id)
        {
          return (_context.StanceEvents?.Any(e => e.eventName == id)).GetValueOrDefault();
        }
    }
}
