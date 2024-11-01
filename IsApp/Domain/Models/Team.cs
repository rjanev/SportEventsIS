using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsApp.Domain.Models
{
    public class Team : BaseEntity
    {
        public string Name { get; set; }
        public string City { get; set; }
        public ICollection<Player> Players { get; set; }= new List<Player>();
    }
}
