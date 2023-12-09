using Hotel.Application.DTO;


namespace Hotel.Application.Features.Booking.Queries.GetBookings
{
    public class BookingsVm
    {
        public string UserId { get; set; } = string.Empty;
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public string? StateDescription{ get; set; }
        public string? HotelName { get; set; }
        public EmergencyContactDTO? EmergencyContact { get; set; }
        public int EmergencyContactId { get; set; }
        public BookingDetailDTO? BookingDetails { get; set; }
    }
}
