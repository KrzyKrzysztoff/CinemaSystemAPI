using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaSystemAPI.Models
{
    public class CreateTicketDto
    {

        public decimal Price { get; set; }
        public int Seat { get; set; }
        public string MovieName { get; set; }
        public int RoomNumber { get; set; }
     
    }
}
