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
    [Route("api/ticket")]
    [ApiController]
    [Authorize]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService ticketService;

        public TicketController(ITicketService ticketService)
        {
            this.ticketService = ticketService;
        }

        [HttpPost("create")]
        public ActionResult Create([FromBody] CreateTicketDto createTicketDto)
        {
            var ticketId = ticketService.Create(createTicketDto);

            if (ticketId == 0)
            {
                return NotFound();
            }

            return Created($"/api/ticket/getById/{ticketId}", null);
        }

        [HttpDelete("delete/{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            ticketService.Delete(id);

            return NoContent();
        }

        [HttpGet("getAll")]
        public ActionResult GetAll()
        {
            var ticekts = ticketService.GetAll();

            if (ticekts == null)
            {
                return NotFound();
            }

            return Ok(ticekts);
        }

        [HttpGet("getById/{id}")]
        public ActionResult GetById([FromRoute] int id)
        {
            var ticket = ticketService.GetById(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(ticket);
        }

        [HttpPut("update/{id}")]
        public ActionResult Update([FromBody] UpdateTicketDto dto, [FromRoute] int id)
        {
            var ticketId = ticketService.Update(dto, id);

            if (ticketId == 0)
            {
                return NotFound();
            }

            return Created($"/api/ticket/getById/{ticketId}", null);
        }
    }
}
