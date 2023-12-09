
namespace Hotel.Application.Features.Hotel.Queries.GetHotelsWithBooking
{
    public class HotelsBokkingVm
    {
        public string HotelName { get; set; } = string.Empty;
        public string Town { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string TypeRoomDescription { get; set; } = string.Empty;
        public decimal BaseCost { get; set; }
        public decimal Taxes { get; set; }
        public int Number { get; set; }
    }

}
