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
        Ticket Create(CreateTicketDto dto);
        TicketDto GetById(int id);
        List<TicketDto> GetAll();
        Ticket Update();
        void Delete(int id);
    }
}
