namespace Hotel.Application.DTO
{
    public class RoomHotelDTO
    {
        public int Number { get; set; }
        public decimal BaseCost { get; set; }
        public decimal Taxes { get; set; }
        public string TypeRoom { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
    }
}
