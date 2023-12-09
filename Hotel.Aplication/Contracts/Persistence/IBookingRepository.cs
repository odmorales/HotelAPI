
using Hotel.Application.Features.Booking.Queries.GetBookings;
using Hotel.Domain;

namespace Hotel.Application.Contracts.Persistence
{
    public interface IBookingRepository : IAsyncRepository<BookingHotel>
    {
        Task<IEnumerable<BookingsVm>> GetBookingsByUserId(string? userId);
    }
}
