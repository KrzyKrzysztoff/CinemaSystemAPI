using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaSystemAPI.Exceptions
{
    public class NotFoundExcption:Exception
    {
        public NotFoundExcption(string message):base(message)
        {
                
        }
    }
}
