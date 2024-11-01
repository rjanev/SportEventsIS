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
using IsApp.Service.Implementation;

namespace IsApp.Web.Controllers
{
    public class PlayersController : Controller
    {
        private readonly IPlayerService _playerService;
        private readonly ITeamService _teamService;


        public PlayersController(IPlayerService playerService, ITeamService teamService)
        {
            _playerService = playerService;
            _teamService = teamService;
        }

        public IActionResult AddPlayerToTeam(Guid? id)
        {
            var players = _playerService.GetDetailsForPlayer(id);
            var teams= _teamService.GetAllTeams();


            var viewModel = new Domain.DTO.AddPlayerToTeamViewModel
            {
                Player = players,
                Teams = teams
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddToTeam(Guid playerId, Guid selectedTeamId)
        {
            var player = _playerService.GetDetailsForPlayer(playerId);
            var team = _teamService.GetDetailsForTeam(selectedTeamId);

            _teamService.AddPlayerToTeam(playerId , selectedTeamId);

            return RedirectToAction(nameof(Index));
        }


        // GET: Players
        public IActionResult Index()
        {
            return View(_playerService.GetAllPlayers());
        }

        // GET: Players/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = _playerService.GetDetailsForPlayer(id);

            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // GET: Players/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Players/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Surname,years, Id")] Player player)
        {


            player.Id = Guid.NewGuid();
            _playerService.CreateNewPlayer(player);
            return RedirectToAction(nameof(Index));

            return View(player);
        }

        // GET: Players/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = _playerService.GetDetailsForPlayer(id);

            if (player == null)
            {
                return NotFound();
            }
            return View(player);
        }

        // POST: Players/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Surname,years,Id")] Player player)
        {
            if (id != player.Id)
            {
                return NotFound();
            }


            try
            {
                _playerService.UpdateExistingPlayer(player);
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;

            }

            return RedirectToAction(nameof(Index));


        }

        // GET: Players/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = _playerService.GetDetailsForPlayer(id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _playerService.DeletePlayer(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
