using InCoqnito.Kalender.Data;
using InCoqnito.Kalender.Models.Models.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InCoqnito.Kalender.Application.Invitation.Queries
{
    public class GetInvitationInfoByIdQueryHandler : IRequestHandler<GetInvitationInfoByIdQuery, InvitationVM>
    {
        private readonly KalenderDBContext _kalenderDb;
        public GetInvitationInfoByIdQueryHandler(KalenderDBContext kalenderDb)
        {
            _kalenderDb = kalenderDb;
        }
        public async Task<InvitationVM> Handle(GetInvitationInfoByIdQuery request, CancellationToken cancellationToken)
        {
            InvitationVM response = null;
            try
            {
                var invitation = await _kalenderDb.Invitation.FirstOrDefaultAsync(i => i.InvitationId == request.InvId);
                response = new InvitationVM()
                {
                    AuthorId = invitation.CreatedBy,
                    AuthorName = invitation.CreatedByNavigation.EmpName,
                    Date = invitation.InvDate,
                    Description = invitation.InvitationDescription,
                    //StartTime = i.StartTime,
                    //EndTime = i.EndTime,
                    Rating = invitation.Rating
                };
            }
            catch (Exception e)
            {
                //TO DO Exception Logging
            }
            return response;
        }
    }
}
