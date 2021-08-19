using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaSystemAPI.Exceptions
{
    public class IsNullOrEmptyException : Exception
    {
        public IsNullOrEmptyException(string message) : base(message)
        {

        }
    }
}
