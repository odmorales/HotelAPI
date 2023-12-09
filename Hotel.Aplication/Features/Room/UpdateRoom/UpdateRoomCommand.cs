using MediatR;

namespace Hotel.Application.Features.Room.UpdateRoom
{
    public class UpdateRoomCommand : IRequest
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public decimal BaseCost { get; set; }
        public decimal Taxes { get; set; }
        public int? HotelCId { get; set; }
        public int TypeRoomId { get; set; }
        public int LocationRoomId { get; set; }
        public bool Available { get; set; }
    }
}
