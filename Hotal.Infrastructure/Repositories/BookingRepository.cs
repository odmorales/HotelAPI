using Hotel.Application.Contracts.Persistence;
using Hotel.Application.DTO;
using Hotel.Application.Features.Booking.Queries.GetBookings;
using Hotel.Domain;
using Hotel.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Infrastructure.Repositories
{
    public class BookingRepository : RepositoryBase<BookingHotel>, IBookingRepository
    {
        public BookingRepository(HotelDbContext context) : base(context) { }

        public async Task<IEnumerable<BookingsVm>> GetBookingsByUserId(string? userId)
        {
            return await _context.BookingHotels!.AsNoTracking().Where(x => x.UserId == userId)
                .Select(x => new BookingsVm
                {
                    ArrivalDate = x.ArrivalDate,
                    DepartureDate = x.DepartureDate,
                    EmergencyContact = new EmergencyContactDTO
                    {
                        Names = x.EmergencyContact!.Names,
                        PhoneNumber = x.EmergencyContact.PhoneNumber,
                    },
                    HotelName = x.HotelC!.Name,
                    StateDescription = x.StateBooking!.Description,
                    BookingDetails = new BookingDetailDTO
                    {
                        Guests = x!.Guests!.Select(g => new GuestDTO
                        {
                            BirthDate = g.BirthDate,
                            DocumentNumber = g.DocumentNumber,
                            Email = g.Email,
                            GenderDescription = g!.Gender!.Nombre,
                            DocumentType = g!.DocumentType!.Name,
                            PhoneNumber = g.PhoneNumber,
                            Name = g.Name,
                            LastName = g.LastName,
                        }),
                        Location = $"Floor: {x.RoomHotel!.LocationRoom!.Foor}, Number: {x.RoomHotel.LocationRoom.Number}",
                        TypeRoomDescription = x.RoomHotel!.TypeRoom!.Name,
                        Town = x.HotelC.Town!.Name,
                    },
                })
                .ToListAsync();
        }
    }
}
