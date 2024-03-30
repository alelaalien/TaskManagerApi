using FluentValidation;
using TaskManager.Domain.DTOs;

namespace TaskManager.Infraestructure.Validators
{
    public class ActivityValidator : AbstractValidator<ActivityDto>
    {
        public ActivityValidator()
        {
           RuleFor(item => item.Name).NotNull();
            //RuleFor(item => item.Date).GreaterThanOrEqualTo(DateTime.Now).NotNull();
        }
    }
}
