using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using InCoqnito.Kalender.Application.Rating.Commands.Update;
using InCoqnito.Kalender.Models.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace InCoqnito.Kalender.Web.Controllers
{

    [Route("api/[controller]")]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class RatingController : BaseController
    {
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