using FluentValidation;

namespace Hotel.Application.Features.Room.CreateRoom
{
    public class CreateRoomCommandValidator : AbstractValidator<CreateRoomCommand>
    {
        public CreateRoomCommandValidator()
        {
            RuleFor(p => p.BaseCost)
               .NotEmpty().WithMessage("{BaseCost} is required")
               .NotNull();

            RuleFor(p => p.Available)
                .NotEmpty().WithMessage("{Available} is required")
                .NotNull();
        }
    }
}
