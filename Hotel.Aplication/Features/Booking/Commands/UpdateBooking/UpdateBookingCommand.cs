
using MediatR;

namespace Hotel.Application.Features.Bookings.Commands.UpdateBooking
{
    public class UpdateBookingCommand : IRequest
    {
        public int Id { get; set; }
        public int StateBookingId { get; set; }
    }
}
