
using Hotel.Domain.Common;

namespace Hotel.Domain
{
    public class HotelC : BaseDomainModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool Available { get; set; }
        public Town? Town { get; set; }
        public int TownId { get; set; }
        public Deparment? Deparment { get; set; }
        public int DeparmentId { get; set; }
        public virtual ICollection<RoomHotel>? Rooms { get; set; }
    }
}
