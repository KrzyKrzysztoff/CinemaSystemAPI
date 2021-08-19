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
    public class RoomService : IRoomService
    {
        private readonly CinemaDbContext cinemaDbContext;
        private readonly IMapper mapper;

        public RoomService(CinemaDbContext cinemaDbContext, IMapper mapper)
        {
            this.cinemaDbContext = cinemaDbContext;
            this.mapper = mapper;
        }

        public int Update(int sessionId, int roomId, UpdateRoomDto dto)
        {

            //check room in session
            var room = RoomInSesion(sessionId, roomId);

            if (room == null || dto == null)
            {
                return 0;
            }

            room.Number = dto.Number;
            room.Capcity = dto.Capcity;

            cinemaDbContext.SaveChanges();

            return room.Id;

        }

        public RoomDto GetById(int sessionId, int roomId)
        {

            //check room in session
            var room =  RoomInSesion(sessionId, roomId);

            if (room == null)
            {
                return null;
            }

            var roomDto = mapper.Map<RoomDto>(room);

            return roomDto;
        }

        private Room RoomInSesion(int sessionId, int roomId)
        {
            //check room in session
            var session = cinemaDbContext.Sessions
               .Include(x => x.Room)
               .FirstOrDefault(x => x.Id == sessionId);

            if (session == null || session.RoomId != roomId)
            {
                return null;
            }

            var room = session.Room;

            return room;
        }

    }
}
