using AutoMapper;
using CinemaSystemAPI.Entities;
using CinemaSystemAPI.Models;
using CinemaSystemAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaSystemAPI.Controllers
{
    [Route("api/{sessionId}/room")]
    [ApiController]
    [Authorize]
    public class RoomController : ControllerBase
    {
        private readonly CinemaDbContext cinemaDbContext;
        private readonly IMapper mapper;
        private readonly IRoomService roomService;

        public RoomController(CinemaDbContext cinemaDbContext,
            IMapper mapper,
            IRoomService roomService)
        {
            this.cinemaDbContext = cinemaDbContext;
            this.mapper = mapper;
            this.roomService = roomService;
        }

        [HttpGet("getById/{id}")]
        public ActionResult GetById([FromRoute] int sessionId, [FromRoute]  int id)
        {
            var room = roomService.GetById(sessionId, id);

            if (room == null)
            {
                return NotFound();
            }

            return Ok(room);
        }

        [HttpPut("update/{id}")]
        public ActionResult Update([FromRoute] int sessionId, [FromRoute] int id, [FromBody] UpdateRoomDto updateRoomDto)
        {
            var roomId = roomService.Update(sessionId, id, updateRoomDto);

            if (roomId == 0)
            {
                return NotFound();
            }

            return Created($"/api/{sessionId}/room/getById/{roomId}", null);
        }
    }
}
