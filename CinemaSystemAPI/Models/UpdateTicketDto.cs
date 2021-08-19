using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaSystemAPI.Models
{
    public class UpdateTicketDto
    {
        public decimal Price { get; set; }
        public int Seat { get; set; }
    }
}
