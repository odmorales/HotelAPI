using Hotel.Domain;
using MediatR;

namespace Hotel.Application.Features.Hotel.Commands.CreateHotel
{
    public class CreateHotelCommand : IRequest<int>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool Available { get; set; }
        public int TownId { get; set; }
        public int DeparmentId { get; set; }
    }
}
