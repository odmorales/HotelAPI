using MediatR;

namespace Hotel.Application.Features.Booking.Queries.GetBookings
{
    public class GetBookingQuery : IRequest<List<BookingsVm>>
    {
        public string _UserId { get; set; }
        public GetBookingQuery(string username)
        {
            _UserId = username ?? throw new ArgumentNullException(nameof(username));
        }
    }
}
