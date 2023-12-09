
using Hotel.Domain;
using MediatR;

namespace Hotel.Application.Features.Room.CreateRoom
{
    public class CreateRoomCommand : IRequest<int>
    {
        public int Number { get; set; }
        public decimal BaseCost { get; set; }
        public decimal Taxes { get; set; }
        public int TypeRoomId { get; set; }
        public int LocationRoomId { get; set; }
        public bool Available { get; set; }
    }
}
