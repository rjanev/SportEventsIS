using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsApp.Domain.Models
{
    public class Player : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public int years { get; set; }

        public Team? Team { get; set; }
        public  Guid? TeamId { get; set; }
    }
}
