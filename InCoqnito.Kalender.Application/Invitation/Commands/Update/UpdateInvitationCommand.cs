using InCoqnito.Kalender.Models.Models.Request;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace InCoqnito.Kalender.Application.Invitation.Commands.Update
{
    public class UpdateInvitationCommand : IRequest<bool>
    {
        public InvitationUpdateRequest updateInvRequest { get; set; }
    }
}
