using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using InCoqnito.Kalender.Application.Invitation.Commands.Create;
using InCoqnito.Kalender.Models.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace InCoqnito.Kalender.Web.Controllers
{

    [Route("api/[controller]")]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class InvitationController : BaseController
    {
        [HttpPost()]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Post([FromBody]InvitationRequest request)
        {
            if(request != null && request.SharedEmails != null && request.SharedEmails.Count > 0)
            {
                return Ok(await Mediator.Send(new CreateInvitationCommand { invitationRequest = request }));
            }
            else
            {
                return NotFound();
            }
        }
    }
}