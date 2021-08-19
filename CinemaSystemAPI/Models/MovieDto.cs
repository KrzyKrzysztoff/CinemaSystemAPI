using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaSystemAPI.Models
{
    public class MovieDto
    {
        public string Author { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int LengthInMinutes { get; set; }
        public int RequiredAge { get; set; }

    }
}
