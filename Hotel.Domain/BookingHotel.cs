using Hotel.Domain.Common;

namespace Hotel.Domain
{
    public class BookingHotel : BaseDomainModel
    {
        public string UserId { get; set; } = string.Empty;
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public StateBooking? StateBooking { get; set; }
        public int StateBookingId { get; set; }
        public HotelC? HotelC { get; set; }
        public int HotelCId { get; set; }
        public virtual EmergencyContact? EmergencyContact { get; set; }
        public int EmergencyContactId { get; set; }
        public virtual RoomHotel? RoomHotel { get; set; }
        public int RoomHotelId { get; set; }
        public virtual ICollection<Guest>? Guests { get; set; }
        //public virtual ICollection<BookingDetail>? BookingDetails { get; set; }
    }
}
