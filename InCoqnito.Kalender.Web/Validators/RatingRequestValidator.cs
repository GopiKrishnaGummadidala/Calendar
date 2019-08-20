using FluentValidation;
using InCoqnito.Kalender.Models.Models.Request;

namespace InCoqnito.Kalender.Web.Validators
{
    public class RatingRequestValidator : AbstractValidator<RatingRequest>
    {
        public RatingRequestValidator()
        {
            RuleFor(i => i.EmpId).NotEqual(0);
            RuleFor(i => i.InvId).NotEqual(0);
        }
    }
}
