using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaSystemAPI.Models
{
    public class TicketDto
    {
        public decimal Price { get; set; }
        public int Seat { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Number { get; set; }
    }
}
