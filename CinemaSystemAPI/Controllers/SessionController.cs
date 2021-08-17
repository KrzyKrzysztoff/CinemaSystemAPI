using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaSystemAPI.Controllers
{
    [Route("api/cinema")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        [HttpGet("getSession/{id}")]
        public ActionResult GetSession()
        {
            return View();
        }
    }
}
