using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using InCoqnito.Kalender.Application.Invitation.Commands.Create;
using Microsoft.AspNetCore.Mvc;

namespace InCoqnito.Kalender.Web.Controllers
{

    [Route("api/[controller]")]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class InvitationController : BaseController
    {
        [HttpGet()]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new CreateInvitationCommand { }));
        }
    }
}