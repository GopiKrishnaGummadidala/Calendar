using InCoqnito.Kalender.Models.Models.Request;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace InCoqnito.Kalender.Application.Invitation.Commands.Create
{
    public class CreateInvitationCommand : IRequest<bool>
    {
        public InvitationRequest invitationRequest { get; set; }
    }
}
