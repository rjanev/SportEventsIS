using IsApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsApp.Domain.DTO
{
    public class AddPlayerToTeamViewModel
    {
        public List<Team> Teams { get; set; } = new List<Team>();
        public Player Player { get; set; } = new Player();
        public Guid SelectedTeamId { get; set; }
    }
}
