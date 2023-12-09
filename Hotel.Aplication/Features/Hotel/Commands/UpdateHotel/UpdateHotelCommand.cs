using Hotel.Application.DTO;
using MediatR;

namespace Hotel.Application.Features.Hotel.Commands.UpdateHotel
{
    public class UpdateHotelCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool Available { get; set; }
    }
}
