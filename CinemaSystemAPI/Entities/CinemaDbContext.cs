using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaSystemAPI.Entities
{
    public class CinemaDbContext : DbContext
    {
        private const string connectionString = "Data Source=127.0.0.1;Initial Catalog=CinemaDb;User ID=sa;Password=Wsh123!@#";

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Ticket> Tickets{ get; set; }
        public DbSet<User> Users{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
