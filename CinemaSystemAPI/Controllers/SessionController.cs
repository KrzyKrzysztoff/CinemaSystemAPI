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

        [HttpGet("getSession/{id}")]
        public ActionResult GetSession([FromRoute] int id)
        {
            var sessionDto = sessionService.GetById(id);

            if (sessionDto is null)
            {
                return NotFound();
            }

            return Ok(sessionDto);
        }
    }
}
