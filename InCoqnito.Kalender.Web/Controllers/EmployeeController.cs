using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using InCoqnito.Kalender.Application.Employee.Queries;
using InCoqnito.Kalender.Models.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace InCoqnito.Kalender.Web.Controllers
{
    [Route("api/[controller]")]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class EmployeeController : BaseController
    {
        // GET: api/Employees
        [HttpGet()]
        [ProducesResponseType(typeof(List<EmployeeVM>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetEmployeesQuery { }));
        }
    }
}