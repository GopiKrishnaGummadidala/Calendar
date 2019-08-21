using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using InCoqnito.Kalender.Application.Rating.Commands.Update;
using InCoqnito.Kalender.Application.Rating.Queries;
using InCoqnito.Kalender.Models.Models.Request;
using InCoqnito.Kalender.Models.Models.Response;
using InCoqnito.Kalender.Web.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace InCoqnito.Kalender.Web.Controllers
{

    [Route("api/[controller]")]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class RatingController : BaseController
    {
        private IHubContext<RatingHub> _hub;

        public RatingController(IHubContext<RatingHub> hub)
        {
            _hub = hub;
        }

        [HttpGet()]
        [ProducesResponseType(typeof(List<InvitationVM>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            await _hub.Clients.All.SendAsync("Rating", await Mediator.Send(new GetAllInvitationRatingQuery { }));
            return Ok();
        }

        [HttpPost()]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Post([FromBody]RatingRequest request)
        {
            if (request != null)
            {
                return Ok(await Mediator.Send(new RatingUpdateCommand { ratingRequest = request }));
            }
            else
            {
                return NotFound();
            }
        }
    }

}