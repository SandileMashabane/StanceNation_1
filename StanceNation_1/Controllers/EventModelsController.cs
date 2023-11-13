using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StanceNation_1.Data;
using StanceNation_1.Models;

namespace StanceNation_1.Controllers
{
    public class EventModelsController : Controller
    {
        private readonly dbContext _context;

        public EventModelsController(dbContext context)
        {
            _context = context;
        }

        // GET: EventModels
        public async Task<IActionResult> Index()
        {
              return _context.Events != null ? 
                          View(await _context.Events.ToListAsync()) :
                          Problem("Entity set 'dbContext.Events'  is null.");
        }

        // GET: EventModels/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }

            var eventModel = await _context.Events
                .FirstOrDefaultAsync(m => m.eventName == id);
            if (eventModel == null)
            {
                return NotFound();
            }

            return View(eventModel);
        }

        // GET: EventModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EventModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("eventName,eventDate,eventImage,eventLocation,eventPrice,eventPrice2,eventTime")] EventsModel eventModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventModel);
        }

        // GET: EventModels/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }

            var eventModel = await _context.Events.FindAsync(id);
            if (eventModel == null)
            {
                return NotFound();
            }
            return View(eventModel);
        }

        // POST: EventModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("eventName,eventDate,eventImage,eventLocation,eventPrice,eventPrice2,eventTime")] EventsModel eventModel)
        {
            if (id != eventModel.eventName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventModelExists(eventModel.eventName))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(eventModel);
        }

        // GET: EventModels/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }

            var eventModel = await _context.Events
                .FirstOrDefaultAsync(m => m.eventName == id);
            if (eventModel == null)
            {
                return NotFound();
            }

            return View(eventModel);
        }

        // POST: EventModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Events == null)
            {
                return Problem("Entity set 'dbContext.Events'  is null.");
            }
            var eventModel = await _context.Events.FindAsync(id);
            if (eventModel != null)
            {
                _context.Events.Remove(eventModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventModelExists(string id)
        {
          return (_context.Events?.Any(e => e.eventName == id)).GetValueOrDefault();
        }
    }
}
