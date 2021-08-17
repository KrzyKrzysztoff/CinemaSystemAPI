using AutoMapper;
using CinemaSystemAPI.Entities;
using CinemaSystemAPI.Exceptions;
using CinemaSystemAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaSystemAPI.Services
{
    public class SessionService : ISessionService
    {
        private readonly CinemaDbContext cinemaDbContext;
        private readonly IMapper mapper;

        public SessionService(CinemaDbContext cinemaDbContext, IMapper mapper)
        {
            this.cinemaDbContext = cinemaDbContext;
            this.mapper = mapper;
        }

        public void Create(CreateSessionDto dto)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<SessionDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public SessionDto GetById(int id)
        {
            var session = cinemaDbContext.Sessions
                .Include(y=>y.Movie)
                .Include(z=>z.Room)
                .FirstOrDefault(x => x.Id == id);

            if (session == null)
            {
                throw new NotFoundExcption("Session not found");
            }

            var sessionDto = mapper.Map<SessionDto>(session);

            return sessionDto;
        }

        public void Update(int id, UpdateSession dto)
        {
            throw new NotImplementedException();
        }
    }
}
