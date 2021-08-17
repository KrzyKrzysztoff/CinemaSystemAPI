using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaSystemAPI.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int Seat { get; set; }

        public int SessionId { get; set; }
        public virtual Session Session { get; set; }
    }
}
