
using FluentValidation;
using Hotel.Application.Features.Hotel.Commands.CreateHotel;

namespace Hotel.Application.Features.Bookings.Commands.UpdateBooking
{
    public class UpdateCommandValidator : AbstractValidator<UpdateBookingCommand>
    {
        public UpdateCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotNull().WithMessage("{Id} is required")
                .NotEmpty();

            RuleFor(p => p.StateBookingId)
                .NotNull().WithMessage("{StateBookingId} is required")
                .NotEmpty();
        }
    }
}
