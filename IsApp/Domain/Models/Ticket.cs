using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsApp.Domain.Models
{
    public class Ticket:BaseEntity
    {
        public Guid SportsEventId { get; set; }
        public SportsEvent? SportsEvent { get; set; }

        [Required]
        public double Price { get; set; }
    }
}
