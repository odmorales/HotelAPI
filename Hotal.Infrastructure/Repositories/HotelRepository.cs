using Hotel.Application.Contracts.Persistence;
using Hotel.Application.DTO;
using Hotel.Application.Features.Hotel.Queries.GetHotelsWithBooking;
using Hotel.Application.Features.Hotel.Queries.GetListHotels;
using Hotel.Domain;
using Hotel.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Infrastructure.Repositories
{
    public class HotelRepository : RepositoryBase<HotelC>, IHotelRepository
    {
        public HotelRepository(HotelDbContext context) : base(context) { }

        public async Task<IEnumerable<HotelsVm>> GetAllHotelsAvailable()
        {
           return await _context.HotelCs.AsNoTracking()
                .Where(x => x.Available)
                .Select(h => new HotelsVm
                {
                    Name = h.Name,
                    DeparmentName = h.Deparment.Name,
                    Description = h.Description,
                    TownName = h!.Town.Name,
                    Rooms =  h.Rooms != null? h.Rooms.Select(r => new RoomHotelDTO
                    {
                        Number = r.Number,
                        Taxes = r.Taxes,
                        BaseCost = r.BaseCost,
                        TypeRoom = r.TypeRoom.Name,
                        Location = $"Floor: {r.LocationRoom.Foor} Number: {r.LocationRoom.Number}"
                    }) : null
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<HotelsBokkingVm>> GetAllHotelsBookings(DateTime arrivalDate, DateTime departureDate, int amount, int townId)
        {
            return await _context.BookingHotels.AsNoTracking()
                .Where(x => (x.DepartureDate >= arrivalDate || x.ArrivalDate <= departureDate) 
                            && (x!.RoomHotel!.Number == amount) && (x!.HotelC!.TownId == townId))
                .Select(h => new HotelsBokkingVm
                {
                    HotelName = h.HotelC.Name,
                    Town = h.HotelC.Town.Name,
                    Department = h.HotelC.Deparment.Name,
                    TypeRoomDescription = h.RoomHotel.TypeRoom.Name,
                    Number = h.RoomHotel.Number,
                    BaseCost = h.RoomHotel.BaseCost,
                    Taxes = h.RoomHotel.Taxes
                })
                .ToListAsync();
        }
    }
}
