using CinemaSystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaSystemAPI.Services
{
    public interface IMovieService
    {
        int Update(int sessionId, int movieId, UpdateMovieDto dto);
        MovieDto GetById(int sessionId, int moveId);
    }
}
