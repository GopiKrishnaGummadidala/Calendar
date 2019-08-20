using InCoqnito.Kalender.Models.Models.Request;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace InCoqnito.Kalender.Application.Rating.Commands.Update
{
    public class RatingUpdateCommand: IRequest<bool>
    {
        public RatingRequest ratingRequest { get; set; }
    }
}
