namespace Hotel.Application.DTO
{
    public class BookingDetailDTO
    {
        public IEnumerable<GuestDTO>? Guests { get; set; }
        public string? Location { get; set; }
        public string? TypeRoomDescription { get; set; }
        public string? Town { get; set; }
    }
}
