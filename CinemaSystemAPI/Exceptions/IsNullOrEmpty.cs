using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaSystemAPI.Exceptions
{
    public class IsNullOrEmpty : Exception
    {
        public IsNullOrEmpty(string message) : base(message)
        {

        }
    }
}
