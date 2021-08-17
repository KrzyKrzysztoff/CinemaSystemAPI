using CinemaSystemAPI.Entities;
using CinemaSystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaSystemAPI.Services
{
    public interface ISessionService
    {
        SessionDto GetById(int id);
        List<SessionDto> GetAll();
        void Create(CreateSessionDto dto);
        void Delete(int id);
        void Update(int id, UpdateSession dto);
    }
}
