using CinemaSystemAPI.Entities;
using CinemaSystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaSystemAPI.Services
{
    public interface ITicketService
    {
        int Create(CreateTicketDto dto);
        TicketDto GetById(int id);
        List<TicketDto> GetAll();
        int Update(UpdateTicketDto dto, int id);
        void Delete(int id);
    }
}
