using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaSystemAPI.Models
{
    public class SessionDto
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Number { get; set; }
        public int Capcity { get; set; }
        public string MovieName { get; set; }
        public string MovieCategory { get; set; }
        public int MovieLengthInMinutes { get; set; }
        public int RequiredAge { get; set; }
    }
}
