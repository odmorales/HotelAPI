using Hotel.Domain.Common;

namespace Hotel.Domain
{
    public class RoomHotel : BaseDomainModel
    {
        public int Number { get; set; }
        public decimal BaseCost { get; set; }
        public decimal Taxes { get; set; }
        public virtual HotelC? HotelC { get; set; }
        public int? HotelCId { get; set; }
        public virtual TypeRoom? TypeRoom { get; set; }
        public int TypeRoomId { get; set; }
        public virtual LocationRoom? LocationRoom { get; set; }
        public int LocationRoomId { get; set; }
        public bool Available { get; set; }
    }
}