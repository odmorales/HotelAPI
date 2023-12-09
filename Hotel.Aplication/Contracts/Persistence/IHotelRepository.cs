using Hotel.Application.Features.Hotel.Queries.GetHotelsWithBooking;
using Hotel.Application.Features.Hotel.Queries.GetListHotels;
using Hotel.Domain;

namespace Hotel.Application.Contracts.Persistence
{
    public interface IHotelRepository : IAsyncRepository<HotelC>
    {
        Task<IEnumerable<HotelsVm>> GetAllHotelsAvailable();
        Task<IEnumerable<HotelsBokkingVm>> GetAllHotelsBookings(DateTime arrivalDate, DateTime departureDate, int amount, int townId);

    }
}
