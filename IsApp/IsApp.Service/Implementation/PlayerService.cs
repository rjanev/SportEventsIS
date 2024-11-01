using IsApp.Domain.Models;
using IsApp.Repository.Interface;
using IsApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsApp.Service.Implementation
{
    public class PlayerService : IPlayerService
    {
        private readonly IRepository<Player> _playerRepo;
        private readonly IRepository<Team> _teamRepo;

        public PlayerService(IRepository<Player> playerRepo, IRepository<Team> teamRepo)
        {
            _playerRepo = playerRepo;
            _teamRepo = teamRepo;
        }

        public void CreateNewPlayer(Player p)
        {
            _playerRepo.Insert(p);
        }

        public void DeletePlayer(Guid id)
        {
            Player ms = _playerRepo.Get(id);
            _playerRepo.Delete(ms);
        }

        public List<Player> GetAllPlayers()
        {
            return _playerRepo.GetAll().ToList();

        }

        public Player GetDetailsForPlayer(Guid? id)
        {

            return _playerRepo.Get(id);
        }

        public void UpdateExistingPlayer(Player p)
        {
            _playerRepo.Update(p);
        }

     

        public List<Player> GetPlayersOnTeam(Guid teamId)
        {
            Team team = _teamRepo.Get(teamId);
            return team.Players.ToList();
        }
    }
}
