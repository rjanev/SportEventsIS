using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsApp.Domain.Models
{
    public class MatchSchedule : BaseEntity
    {
        public DateTime Date { get; set; }

        public Guid TeamId1 { get; set; }
        public Team? Team1 { get; set; }

        public Guid TeamId2 { get; set; }
        public Team? Team2 { get; set; }

        public Guid SportEventsId { get; set; }
        public SportsEvent? SportsEvent { get; set; }
    }
}
