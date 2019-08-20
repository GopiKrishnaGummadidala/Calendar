using InCoqnito.Kalender.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InCoqnito.Kalender.Application.Invitation.Commands.Update
{
    public class UpdateInvitationCommandHandler : IRequestHandler<UpdateInvitationCommand, bool>
    {
        private readonly KalenderDBContext _kalenderDb;
        public UpdateInvitationCommandHandler(KalenderDBContext kalenderDb)
        {
            _kalenderDb = kalenderDb;
        }
        public async Task<bool> Handle(UpdateInvitationCommand request, CancellationToken cancellationToken)
        {
            bool response = false;
            try
            {
                var invitation = await _kalenderDb.EmployeeInvitationMap.FirstOrDefaultAsync(i => i.InvitationId == request.updateInvRequest.InvId && i.EmpId == request.updateInvRequest.EmpId);
                if(invitation != null)
                {
                    invitation.IsAccepted = request.updateInvRequest.Status;
                    invitation.Comments = request.updateInvRequest.Comments;
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
