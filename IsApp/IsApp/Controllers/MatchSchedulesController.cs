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
    public class MatchSchedulesController : Controller
    {
        private readonly IMatchScheduleService _matchScheduleService;
        private readonly ITeamService _teamService;
        private readonly ISportsEventService _sportsEventService;

        public MatchSchedulesController(IMatchScheduleService matchScheduleService, ITeamService teamService, ISportsEventService sportsEventService)
        {
            _matchScheduleService = matchScheduleService;
            _teamService = teamService;
            _sportsEventService = sportsEventService;
        }

        // GET: MatchSchedules/Create
        public IActionResult Create(Guid id)
        {
            var teams=_teamService.GetAllTeams();
            var se = _sportsEventService.GetDetailsForSportsEvent(id);

            ViewData["Team"]=teams;
            ViewData["Events"]=se;

            return View();
        }

        // POST: MatchSchedules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Date,TeamId1,TeamId2,SportEventsId,Id")] MatchSchedule matchSchedule)
        {
            var teams = _teamService.GetAllTeams();
            var se = _sportsEventService.GetDetailsForSportsEvent(matchSchedule.SportEventsId);

            ViewData["Team"] = teams;
            ViewData["Events"] = _sportsEventService.GetDetailsForSportsEvent(matchSchedule.SportEventsId);

            if (matchSchedule.TeamId1!=matchSchedule.TeamId2)
            {
                matchSchedule.Id = Guid.NewGuid();
                _matchScheduleService.CreateNewMatchSchedule(matchSchedule);
                return RedirectToAction("Index","SportsEvents");
            }

            ModelState.AddModelError("TeamId2", "The two teams must be different.");

            return View(matchSchedule);
        }

        // GET: MatchSchedules/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matchSchedule =_matchScheduleService.GetDetailsForMatchSchedule(id);    

            if (matchSchedule == null)
            {
                return NotFound();
            }
            return View(matchSchedule);
        }

        // POST: MatchSchedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Date,TeamId1,TeamId2,SportEventsId,Id")] MatchSchedule matchSchedule)
        {
            if (id != matchSchedule.Id)
            {
                return NotFound();
            }

            
                try
                {
                    _matchScheduleService.UpdateExistingMatchSchedule(matchSchedule);   
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
             return RedirectToAction("Index", "SportsEvents");
           
        }

        // GET: MatchSchedules/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matchSchedule = _matchScheduleService.GetDetailsForMatchSchedule(id);

            if (matchSchedule == null)
            {
                return NotFound();
            }

            return View(matchSchedule);
        }

        // POST: MatchSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
           _matchScheduleService.DeleteMatchSchedule(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
