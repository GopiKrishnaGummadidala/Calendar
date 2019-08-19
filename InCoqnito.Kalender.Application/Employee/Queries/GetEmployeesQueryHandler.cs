using InCoqnito.Kalender.Data;
using InCoqnito.Kalender.Models.Models.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InCoqnito.Kalender.Application.Employee.Queries
{
    public class GetEmployeesQueryHandler: IRequestHandler<GetEmployeesQuery, List<EmployeeVM>>
    {
        private readonly KalenderDBContext _kalenderDb;
        public GetEmployeesQueryHandler(KalenderDBContext kalenderDb)
        {
            _kalenderDb = kalenderDb;
        }
        public async Task<List<EmployeeVM>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            List<EmployeeVM> response = null;
            try
            {
                response = await _kalenderDb.Employee.Where(e => e.IsActive == true).Select(s => new EmployeeVM { Id = s.EmpId, EmailId = s.EmpEmailId, Name=s.EmpName }).ToListAsync();
            }
            catch(Exception e)
            {
                //TO DO Exception Logging
            }
            return response;
        }
    }
}
