using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaSystemAPI.Entities
{
    public class Session
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public int MovieId { get; set; }
        public virtual Movie Movie{ get; set; }

        public int RoomId { get; set; }
        public virtual Room Room{ get; set; }

        public Ticket Ticket { get; set; }

    }
}
