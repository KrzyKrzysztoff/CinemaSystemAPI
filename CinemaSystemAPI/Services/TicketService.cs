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
    public class TicketService : ITicketService
    {
        private readonly CinemaDbContext cinemaDbContext;
        private readonly IMapper mapper;

        public TicketService(CinemaDbContext cinemaDbContext, IMapper mapper)
        {
            this.cinemaDbContext = cinemaDbContext;
            this.mapper = mapper;
        }

        public int Create(CreateTicketDto dto)
        {
            if (dto == null)
            {
                return 0;
            }

            var ticket = mapper.Map<Ticket>(dto);

            var sessionForTicketExist = cinemaDbContext.Sessions
                .Include(x => x.Movie)
                .Include(x => x.Room)
                .Where(x => x.Movie.Name == dto.MovieName && x.Room.Number == dto.RoomNumber);

            if(!sessionForTicketExist.Any())
            {
                throw new BadRequestException("Invalid room number or movie name");
            }

            var session = sessionForTicketExist.FirstOrDefault();

            ticket.Session = session;

            cinemaDbContext.Tickets.Add(ticket);

            cinemaDbContext.SaveChanges();

            return ticket.Id;
        }

        public void Delete(int id)
        {
            var ticket = cinemaDbContext.Tickets.FirstOrDefault(x => x.Id == id);

            if (id == 0 || ticket == null)
            {
                throw new NotFoundException("Ticket not found");
            }

            cinemaDbContext.Tickets.Remove(ticket);

            cinemaDbContext.SaveChanges();
        }

        public List<TicketDto> GetAll()
        {
            var tickets = cinemaDbContext.Tickets
                .Include(x => x.Session)
                .Include(x => x.Session.Room)
                .ToList();

            if (!tickets.Any())
            {
                return null;
            }

            var ticketsDto = mapper.Map<List<TicketDto>>(tickets);

            return ticketsDto;
        }

        public TicketDto GetById(int id)
        {
           
            var ticket = cinemaDbContext.Tickets
                .Include(x=>x.Session)
                .Include(x=>x.Session.Room)
                .FirstOrDefault(x => x.Id == id);


            if (ticket == null )
            {
                return null;
            }

            var ticketDto = mapper.Map<TicketDto>(ticket);

            return ticketDto;
        }

        public int Update(UpdateTicketDto ticketUpdateDto, int id)
        {

            if (ticketUpdateDto == null)
            {
                throw new IsNullOrEmptyException("Object is null or empty");
            }

            var ticket = cinemaDbContext.Tickets.FirstOrDefault(x => x.Id == id);

            if (ticket == null)
            {
                return 0;
            }

            ticket.Price = ticketUpdateDto.Price;
            ticket.Seat = ticketUpdateDto.Seat;

            cinemaDbContext.SaveChanges();

            return ticket.Id;

        }

       
    }
}
