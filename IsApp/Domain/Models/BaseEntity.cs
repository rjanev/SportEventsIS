using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsApp.Domain.Models
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
