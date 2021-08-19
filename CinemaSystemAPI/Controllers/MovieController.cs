using AutoMapper;
using CinemaSystemAPI.Entities;
using CinemaSystemAPI.Models;
using CinemaSystemAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaSystemAPI.Controllers
{
    [Route("api/{sessionId}/movie")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly CinemaDbContext cinemaDbContext;
        private readonly IMapper mapper;
        private readonly IMovieService movieService;

        public MovieController(CinemaDbContext cinemaDbContext,
            IMapper mapper,
            IMovieService movieService)
        {
            this.cinemaDbContext = cinemaDbContext;
            this.mapper = mapper;
            this.movieService = movieService;
        }

        [HttpGet("getById/{id}")]
        public ActionResult GetById([FromRoute] int sessionId, [FromRoute] int id)
        {
            var movie = movieService.GetById(sessionId, id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        [HttpPut("update/{id}")]
        public ActionResult Update([FromRoute] int sessionId, [FromRoute] int id, [FromBody] UpdateMovieDto updateMovieDto)
        {
            var movieId = movieService.Update(sessionId, id, updateMovieDto);

            if (movieId == 0)
            {
                return NotFound();
            }

            return Created($"/api/{sessionId}/room/getById/{movieId}", null);
        }
    }
}
