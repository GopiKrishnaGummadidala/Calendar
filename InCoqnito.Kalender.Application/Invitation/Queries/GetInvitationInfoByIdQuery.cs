using InCoqnito.Kalender.Models.Models.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace InCoqnito.Kalender.Application.Invitation.Queries
{
    public class GetInvitationInfoByIdQuery: IRequest<InvitationVM>
    {
        public int InvId { get; set; }
    }
}
