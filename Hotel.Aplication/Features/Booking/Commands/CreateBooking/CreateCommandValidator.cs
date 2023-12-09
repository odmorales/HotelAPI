using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Features.Bookings.Commands.CreateBooking
{
    public class CreateCommandValidator : AbstractValidator<CreateBookingCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(b => b.ArrivalDate)
                .NotEmpty().WithMessage("{ArrivalDate} is Required")
                .NotNull();

            RuleFor(b => b.DepartureDate)
                .NotEmpty().WithMessage("{ArrivalDate} is Required")
                .NotNull();
        }
    }
}
