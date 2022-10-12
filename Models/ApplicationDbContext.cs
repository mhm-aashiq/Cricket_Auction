using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.EntityFrameworkCore;


namespace Cricket_Auction.Models
{
    public class ApplicationDbContext : DbContext
    {
        //internal IEnumerable<object> UserProfiles;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Player> Player { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<TeamOwner> TeamOwner { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<Trophy> trophies { get; set; }
    }
}
