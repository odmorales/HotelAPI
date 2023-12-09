using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Features.Room.UpdateRoom
{
    public class UpdateRoomCommandValidator : AbstractValidator<UpdateRoomCommand>
    {
        public UpdateRoomCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{Id} is required")
                .NotNull();
        }
    }
}
