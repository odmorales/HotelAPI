
namespace Hotel.Application.DTO
{
    public class BookingDetailCreateDTO
    {
        public GuestCreateDTO? Guest { get; set; }
        public int RoomHotelId { get; set; }
    }
}
