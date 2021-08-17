using CinemaSystemAPI.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaSystemAPI.Seeders
{
    public class CinemaSeeder
    {
        private readonly CinemaDbContext cinemaDbContext;
        private readonly IPasswordHasher<User> passwordHasher;

        public CinemaSeeder(CinemaDbContext cinemaDbContext, IPasswordHasher<User> passwordHasher)
        {
            this.cinemaDbContext = cinemaDbContext;
            this.passwordHasher = passwordHasher;
        }

        public void Seed()
        {
            if (cinemaDbContext.Database.CanConnect())
            {
                var pandingMigration = cinemaDbContext.Database.GetPendingMigrations();

                if (pandingMigration != null && pandingMigration.Any())
                {
                    cinemaDbContext.Database.Migrate();
                }

                if (!cinemaDbContext.Sessions.Any())
                {
                    var sessions = GetSessions();
                    cinemaDbContext.Sessions.AddRange(sessions);
                    cinemaDbContext.SaveChanges();
                }

                if (!cinemaDbContext.Tickets.Any())
                {
                    var ticekts = GetTickets();
                    cinemaDbContext.Tickets.AddRange(ticekts);
                    cinemaDbContext.SaveChanges();
                }

                if (!cinemaDbContext.Roles.Any())
                {
                    var role = GetRole();
                    cinemaDbContext.Roles.Add(role);
                    cinemaDbContext.SaveChanges();
                }

                if (!cinemaDbContext.Users.Any())
                {
                    var users = GetUsers();
                    cinemaDbContext.Users.AddRange(users);
                    cinemaDbContext.SaveChanges();
                }

            }
        }
        private IEnumerable<Session> GetSessions()
        {
            var sessions = new List<Session>()
        {
            new Session
            {
              Start = new DateTime(2021, 5, 25, 10, 0, 0)
              ,End = new DateTime(2021, 5, 25, 11, 30, 0)
              ,Room = new Room(){Number = 10, Capcity = 100 }
              ,Movie = new Movie(){Author = "xyz", Category = "comedy", LengthInMinutes = 90, Name = "xyzName", RequiredAge= 12 }

            },

            new Session
            {
              Start = new DateTime(2021, 5, 25, 10, 0, 0)
              ,End = new DateTime(2021, 5, 25, 12, 0, 0)
              ,Room = new Room(){Number = 1, Capcity = 40 }
              ,Movie = new Movie(){Author = "xyz", Category = "Horror", LengthInMinutes = 60, Name = "xyzName", RequiredAge= 18 }

            },

            new Session
            {
              Start = new DateTime(2021, 5, 25, 10, 0, 0)
              ,End = new DateTime(2021, 5, 25, 12, 0, 0)
              ,Room = new Room(){Number = 10, Capcity = 100 }
              ,Movie = new Movie(){Author = "xyz", Category = "Biography", LengthInMinutes = 120, Name = "xyzName", RequiredAge= 6 }

            }

        };

            return sessions;
        }

        private IEnumerable<Ticket> GetTickets()
        {
            var session = cinemaDbContext.Sessions.FirstOrDefault(x => x.Movie.Name == "xyzName");

            var ticets = new List<Ticket>()
            {
                new Ticket {Price = 10, Seat = 1, Session = session},
                new Ticket {Price = 5, Seat = 45, Session = session},
                new Ticket {Price = 15, Seat = 10, Session = session},
                new Ticket {Price = 12, Seat = 11, Session = session},
                new Ticket {Price = 12, Seat = 12, Session = session},
                new Ticket {Price = 12, Seat = 13, Session = session},
            };

            return ticets;
        }

        private Role GetRole()
        {
            var role = new Role()
            {
                Name = "Admin"
            };

            return role;
        }

        private IEnumerable<User> GetUsers()
        {
            var role = cinemaDbContext.Roles.FirstOrDefault(x => x.Name == "admin");


            var users = new List<User>()
            {
                new User { Email = "admin@email.com", FirstName = "Adam", LastName = "Janusz", Role = role},
                new User { Email = "admin2@email.com", FirstName = "Ewa", LastName = "Janusz", Role = role},
                new User { Email = "admin3@email.com", FirstName = "Tomek", LastName = "Janusz", Role = role}
            };

            foreach (var user in users)
            {
                user.PasswordHash = passwordHasher.HashPassword(user, "admin123!@#");
            }

            return users;
        }
    }



}
