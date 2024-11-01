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
    public class TeamService:ITeamService
    {
        private readonly IRepository<Team> _teamRepo;
        private readonly IRepository<Player> _playerRepo;

        public TeamService(IRepository<Team> teamRepo, IRepository<Player> playerRepo)
        {
            _teamRepo = teamRepo;
            _playerRepo = playerRepo;
        }
        public void CreateNewTeam(Team p)
        {
            _teamRepo.Insert(p);
        }

        public void DeleteTeam(Guid id)
        {
            Team team = _teamRepo.Get(id);
            _teamRepo.Delete(team);
        }

        public List<Team> GetAllTeams()
        {
            return _teamRepo.GetAll().ToList();
        }

        public Team GetDetailsForTeam(Guid? id)
        {
            return _teamRepo.Get(id);
        }

        public void UpdateExistingTeam(Team p)
        {
            _teamRepo.Update(p);
        }
        public void AddPlayerToTeam(Guid playerId, Guid teamId)
        {
            Player ms = _playerRepo.Get(playerId);
            Team team = _teamRepo.Get(teamId);

            team.Players.Add(ms);
            _teamRepo.Update(team);
        }

    }
}
