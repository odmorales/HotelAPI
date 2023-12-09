using Hotel.Application.DTO;
using MediatR;

namespace Hotel.Application.Features.Bookings.Commands.CreateBooking
{
    public class CreateBookingCommand : IRequest<int>
    {
        public string UserId { get; set; } = string.Empty;
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public int StateBookingId { get; set; }
        public int HotelCId { get; set; }
        public int RoomHotelId { get; set; }
        public EmergencyContactDTO? EmergencyContact { get; set; }
        public List<GuestCreateDTO>? Guests { get; set; }
    }
}
