using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaSystemAPI.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Capcity { get; set; }

        public Session Session { get; set; }

    }
}
