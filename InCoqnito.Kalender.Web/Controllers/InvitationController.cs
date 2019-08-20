using System.Net;
using System.Threading.Tasks;
using InCoqnito.Kalender.Application.Invitation.Commands.Create;
using InCoqnito.Kalender.Application.Invitation.Commands.Update;
using InCoqnito.Kalender.Application.Invitation.Queries;
using InCoqnito.Kalender.Models.Models.Request;
using InCoqnito.Kalender.Models.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace InCoqnito.Kalender.Web.Controllers
{

    [Route("api/[controller]")]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class InvitationController : BaseController
    {
        [HttpPost()]
        [ProducesResponseType(typeof(InvitationVM), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            if (id != 0)
            {
                return Ok(await Mediator.Send(new GetInvitationInfoByIdQuery { InvId = id }));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost()]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Post([FromBody]InvitationRequest request)
        {
            if(request != null)
            {
                return Ok(await Mediator.Send(new CreateInvitationCommand { invitationRequest = request }));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost()]
        [Route("InvitationUpdate")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> InvitationUpdate([FromBody]InvitationUpdateRequest request)
        {
            if (request != null)
            {
                return Ok(await Mediator.Send(new UpdateInvitationCommand { updateInvRequest = request }));
            }
            else
            {
                return NotFound();
            }
        }
    }
}