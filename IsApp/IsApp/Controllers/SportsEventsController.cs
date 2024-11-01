using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IsApp.Domain.Models;
using IsApp.Repository;
using IsApp.Service.Interface;

namespace IsApp.Web.Controllers
{
    public class SportsEventsController : Controller
    {
        private readonly ISportsEventService _eventService;
        private readonly IMatchScheduleService _matchScheduleService;


        public SportsEventsController(ISportsEventService eventService, IMatchScheduleService matchScheduleService)
        {
            _eventService = eventService;
            _matchScheduleService = matchScheduleService;
        }

        // GET: SportsEvents
        public IActionResult Index()
        {
            return View(_eventService.GetAllSportsEvents());
        }

        // GET: SportsEvents/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportsEvent = _eventService.GetDetailsForSportsEvent(id);
            var matches = _matchScheduleService.GetAllMatchSchedules()
                .Where(match => match.SportEventsId == id).ToList();



            sportsEvent.MatchSchedules = matches;


            if (sportsEvent == null)
            {
                return NotFound();
            }

            return View(sportsEvent);
        }

        // GET: SportsEvents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SportsEvents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Id")] SportsEvent sportsEvent)
        {          
                sportsEvent.Id = Guid.NewGuid();
               _eventService.CreateNewSportsEvent(sportsEvent); 
                return RedirectToAction(nameof(Index));
        }

        // GET: SportsEvents/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportsEvent = _eventService.GetDetailsForSportsEvent(id);
            if (sportsEvent == null)
            {
                return NotFound();
            }
            return View(sportsEvent);
        }

        // POST: SportsEvents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Name,Id")] SportsEvent sportsEvent)
        {
            if (id != sportsEvent.Id)
            {
                return NotFound();
            }

           
                try
                {
                    _eventService.UpdateExistingSportsEvent (sportsEvent);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                    
                }
                return RedirectToAction(nameof(Index));
            
        }

        // GET: SportsEvents/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportsEvent = _eventService.GetDetailsForSportsEvent (id);
            if (sportsEvent == null)
            {
                return NotFound();
            }

            return View(sportsEvent);
        }

        // POST: SportsEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
           _eventService.DeleteSportsEvent (id);
            return RedirectToAction(nameof(Index));
        }
    }
}
