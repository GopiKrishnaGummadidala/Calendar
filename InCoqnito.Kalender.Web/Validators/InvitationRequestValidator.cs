using FluentValidation;
using InCoqnito.Kalender.Models.Models.Request;
using System;

namespace InCoqnito.Kalender.Web.Validators
{
    public class InvitationRequestValidator : AbstractValidator<InvitationRequest>
    {
        public InvitationRequestValidator()
        {
            RuleFor(i => i.AuthorId).NotEqual(0);
            //RuleFor(i => i.Date).NotNull().GreaterThanOrEqualTo(DateTime.Now);
            RuleFor(i => i.Description).NotEmpty();
            RuleFor(i => i.StartTime).NotNull().NotEmpty();
            RuleFor(i => i.EndTime).NotNull().NotEmpty();
            RuleFor(i => i.SharedEmails).NotNull();
            RuleFor(i => i.SharedEmails.Count).NotEqual(0);
        }
    }
}
