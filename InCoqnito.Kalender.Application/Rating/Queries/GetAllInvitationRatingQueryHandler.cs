using InCoqnito.Kalender.Data;
using InCoqnito.Kalender.Models.Models.Response;
using MediatR;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InCoqnito.Kalender.Application.Rating.Queries
{
    public class GetAllInvitationRatingQueryHandler : IRequestHandler<GetAllInvitationRatingQuery, List<InvitationVM>>
    {
        private readonly KalenderDBContext _kalenderDb;
        public GetAllInvitationRatingQueryHandler(KalenderDBContext kalenderDb)
        {
            _kalenderDb = kalenderDb;
        }
        public async Task<List<InvitationVM>> Handle(GetAllInvitationRatingQuery request, CancellationToken cancellationToken)
        {
            List<InvitationVM> response = null;
            try
            {
                response = await _kalenderDb.Invitation.Select(s =>
                 new InvitationVM()
                 {
                     AuthorId = s.CreatedBy,
                     AuthorName = s.CreatedByNavigation.EmpName,
                     Date = s.InvDate,
                     Description = s.InvitationDescription,
                     //StartTime = i.StartTime,
                     //EndTime = i.EndTime,
                     Rating = s.Rating
                 }).ToListAsync();
            }
            catch (Exception e)
            {
                //TO DO Exception Logging
            }
            return response;
        }
    }
}
