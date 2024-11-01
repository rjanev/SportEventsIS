using IsApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsApp.Service.Interface
{
    public interface IPlayerService
    {
        List<Player> GetAllPlayers();
        Player GetDetailsForPlayer(Guid? id);
        void CreateNewPlayer(Player p);
        void UpdateExistingPlayer(Player p);
        void DeletePlayer(Guid id);
        List<Player> GetPlayersOnTeam(Guid teamId);
    }
}
