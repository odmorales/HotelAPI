using FluentValidation;

namespace Hotel.Application.Features.Hotel.Commands.CreateHotel
{
    public class CreateCommandValidator : AbstractValidator<CreateHotelCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{Name} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{Name} cannot exceed 50 characters");

            RuleFor(p => p.Available)
                .NotEmpty().WithMessage("{Available} is required")
                .NotNull();
        }
    }
}
