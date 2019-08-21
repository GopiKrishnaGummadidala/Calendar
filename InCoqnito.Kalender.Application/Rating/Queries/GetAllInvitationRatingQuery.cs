using InCoqnito.Kalender.Models.Models.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace InCoqnito.Kalender.Application.Rating.Queries
{
    public class GetAllInvitationRatingQuery : IRequest<List<InvitationVM>>
    {
    }
}
