using InCoqnito.Kalender.Models.Models.Response;
using MediatR;
using System.Collections.Generic;

namespace InCoqnito.Kalender.Application.Employee.Queries
{
    public class GetEmployeesQuery : IRequest<List<EmployeeVM>>
    {
    }
}
