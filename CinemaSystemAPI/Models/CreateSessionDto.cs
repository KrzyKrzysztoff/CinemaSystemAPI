using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaSystemAPI.Models
{
    public class CreateSessionDto
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int RoomNumber { get; set; }
        public int RoomCapcity { get; set; }
        public string MovieAuthor { get; set; }
        public string MovieCategory { get; set; }
        public int MovieLengthInMinutes { get; set; }
        public string MovieName { get; set; }
        public int MovieRequiredAge { get; set; }
    }
}
