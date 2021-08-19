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

        public Session Create(CreateSessionDto dto)
        {
            var session = mapper.Map<Session>(dto);

            if (session == null)
            {
                throw new IsNullOrEmptyException("Object is null or empty");
            }

            cinemaDbContext.Sessions.Add(session);

            cinemaDbContext.SaveChanges();

            return session;
        }

        public void Delete(int id)
        {
            var session = cinemaDbContext.Sessions.FirstOrDefault(x => x.Id == id);

            if (id == 0 || session == null)
            {
                throw new NotFoundException("Not found session");
            }

            cinemaDbContext.Remove(session);

            cinemaDbContext.SaveChanges();

          
        }

        public List<SessionDto> GetAll()
        {
            var sessions = cinemaDbContext
                .Sessions
                .Include(x=>x.Movie)
                .Include(y=>y.Room)
                .ToList();

            if (sessions == null)
            {
                return null;
            }

            var sessionsDto = mapper.Map<List<SessionDto>>(sessions);

            return sessionsDto;
        }

        public SessionDto GetById(int id)
        {
            var session = cinemaDbContext.Sessions
                .Include(y=>y.Movie)
                .Include(z=>z.Room)
                .FirstOrDefault(x => x.Id == id);

            if (session == null)
            {
                return null;
            }

            var sessionDto = mapper.Map<SessionDto>(session);

            return sessionDto;
        }

        public Session Update(int id, UpdateSessionDto dto)
        {
            if (dto == null || id == 0)
            {
                throw new IsNullOrEmptyException("Objec is null or empty");
            }

            var session = cinemaDbContext.Sessions
                .FirstOrDefault(x => x.Id == id);

            if (session == null)
            {
                throw new NotFoundException("Session not found");
            }

            session.Start = dto.Start;
            session.End = dto.End;
           
            cinemaDbContext.SaveChanges();

            return session;
        }

       
    }
}
