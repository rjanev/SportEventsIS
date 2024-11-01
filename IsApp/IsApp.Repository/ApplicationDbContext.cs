using IsApp.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IsApp.Repository
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<MatchSchedule> MatchSchedules{ get; set; }
        public virtual DbSet<SportsEvent> SportsEvent { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }

    }
}
