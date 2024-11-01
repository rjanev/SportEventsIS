using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace IsApp.Domain.Models
{
    public class SportsEvent : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<MatchSchedule>? MatchSchedules { get; set; }
        public virtual ICollection<Ticket>? Tickets { get; set; }

    }
}
