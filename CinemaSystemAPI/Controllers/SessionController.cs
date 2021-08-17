using CinemaSystemAPI.Models;
using CinemaSystemAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaSystemAPI.Controllers
{
    [Route("api/session")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly ISessionService sessionService;

        public SessionController(ISessionService sessionService)
        {
            this.sessionService = sessionService;
        }

        [HttpGet("getById/{id}")]
        public ActionResult GetById([FromRoute] int id)
        {
            var sessionDto = sessionService.GetById(id);

            if (sessionDto is null)
            {
                return NotFound();
            }

            return Ok(sessionDto);
        }

        [HttpGet("getAll")]
        public ActionResult GetAll()
        {
            var sesionsDto = sessionService.GetAll();

            if (sesionsDto is null)
            {
                return NotFound();
            }

            return Ok(sesionsDto);
        }

        [HttpDelete("delete/{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            sessionService.Delete(id);

            return NoContent();
        }

        [HttpPost("create")]
        public ActionResult Create([FromBody] CreateSessionDto createSessionDto)
        {
            var session = sessionService.Create(createSessionDto);

            int id = session.Id;

            return Created($"/api/session/getById/{id}", null);
        }

        [HttpPut("update/{id}")]
        public ActionResult Update([FromBody] UpdateSessionDto updateSessionDto, [FromRoute] int id)
        {
            var session = sessionService.Update(id, updateSessionDto);

            return Created($"/api/session/getById/{id}", null);
        }
    }
}
