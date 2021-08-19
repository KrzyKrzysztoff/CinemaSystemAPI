using AutoMapper;
using CinemaSystemAPI.Entities;
using CinemaSystemAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaSystemAPI.Services
{
    public class MovieService : IMovieService
    {

        private readonly CinemaDbContext cinemaDbContext;
        private readonly IMapper mapper;

        public MovieService(CinemaDbContext cinemaDbContext, IMapper mapper)
        {
            this.cinemaDbContext = cinemaDbContext;
            this.mapper = mapper;
        }

        public MovieDto GetById(int sessionId, int moveId)
        {
            //check movie in session
            var movie = MovieInSesion(sessionId, moveId);

            if (movie == null)
            {
                return null;
            }

            var movieDto = mapper.Map<MovieDto>(movie);

            return movieDto;
        }

        public int Update(int sessionId, int movieId, UpdateMovieDto dto)
        {
            //check movie in session
            var movie = MovieInSesion(sessionId, movieId);

            if (movie == null || dto == null)
            {
                return 0;
            }

            movie.Author = dto.Author;
            movie.Category = dto.Category;
            movie.LengthInMinutes = dto.LengthInMinutes;
            movie.Name = dto.Name;
            movie.RequiredAge = dto.RequiredAge;

            cinemaDbContext.SaveChanges();

            return movie.Id;
        }

        private Movie MovieInSesion(int sessionId, int movieId)
        {
            //check movie in session
            var session = cinemaDbContext.Sessions
               .Include(x => x.Movie)
               .FirstOrDefault(x => x.Id == sessionId);

            if (session == null || session.MovieId != movieId)
            {
                return null;
            }

            var movie = session.Movie;

            return movie;
        }
    }
}
