using Hotel.Application.DTO;

namespace Hotel.Application.Features.Hotel.Queries.GetListHotels
{
    public class HotelsVm
    {
        public string? Name { get; set; } 
        public string? Description { get; set; }
        public string? TownName { get; set; }
        public string? DeparmentName { get; set; }
        public IEnumerable<RoomHotelDTO>? Rooms { get; set; }
    }
}
