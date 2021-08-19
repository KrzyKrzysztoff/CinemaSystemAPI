using CinemaSystemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaSystemAPI.Services
{
    public interface IRoomService
    {
        int Update(int sessionId, int roomId, UpdateRoomDto dto);
        RoomDto GetById(int sessionId, int roomId);
    }
}
