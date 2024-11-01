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
    public class TeamsController : Controller
    {

        private readonly ITeamService _teamService;
        private readonly IPlayerService _playerService;


        public TeamsController(ITeamService teamService, IPlayerService playerService)
        {
            _teamService = teamService;
            _playerService = playerService;
        }


        [HttpPost]
        public IActionResult AddToTeam(Guid selectedPlayerId, Guid teamId)
        {
            var player = _playerService.GetDetailsForPlayer(selectedPlayerId);
            var team = _teamService.GetDetailsForTeam(teamId);

            _teamService.AddPlayerToTeam(selectedPlayerId, teamId);

            return RedirectToAction(nameof(Index));
        }


        // GET: Teams
        public IActionResult Index()
        {
            return View(_teamService.GetAllTeams());
        }

        // GET: Teams/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = _teamService.GetDetailsForTeam (id);

            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // GET: Teams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,City,Id")] Team team)
        {


            team.Id = Guid.NewGuid();
            _teamService.CreateNewTeam(team);
            return RedirectToAction(nameof(Index));

            return View(team);
        }

        // GET: Teams/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = _teamService.GetDetailsForTeam(id);






            if (team == null)
            {
                return NotFound();
            }
            return View(team);
        }

        // POST: Teams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Name,City,Id")] Team team)
        {
            if (id != team.Id)
            {
                return NotFound();
            }

            try
            {
                _teamService.UpdateExistingTeam(team);
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;

            }

            return View(team);
        }

        // GET: Teams/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = _teamService.GetDetailsForTeam(id);


            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _teamService.DeleteTeam(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
