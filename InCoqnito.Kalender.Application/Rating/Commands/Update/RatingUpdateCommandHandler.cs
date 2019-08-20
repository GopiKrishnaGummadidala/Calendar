using InCoqnito.Kalender.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InCoqnito.Kalender.Application.Rating.Commands.Update
{
    public class RatingUpdateCommandHandler : IRequestHandler<RatingUpdateCommand, bool>
    {
        private readonly KalenderDBContext _kalenderDb;
        public RatingUpdateCommandHandler(KalenderDBContext kalenderDb)
        {
            _kalenderDb = kalenderDb;
        }
        public async Task<bool> Handle(RatingUpdateCommand request, CancellationToken cancellationToken)
        {
            bool response = false;
            try
            {
                var invitation = await _kalenderDb.EmployeeInvitationMap.FirstOrDefaultAsync(i => i.InvitationId == request.ratingRequest.InvId && i.EmpId == request.ratingRequest.EmpId);
                if (invitation != null)
                {
                    invitation.Rating = request.ratingRequest.Rating;
                    var res = await _kalenderDb.SaveChangesAsync();
                    if (res > 0)
                    {
                        response = true;
                    }
                }
            }
            catch (Exception e)
            {
                //TO DO Exception Logging
            }
            return response;
        }
    }
}
