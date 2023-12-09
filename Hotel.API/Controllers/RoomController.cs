using Hotel.Application.Features.Booking.Queries.GetBookings;
using Hotel.Application.Features.Bookings.Commands.UpdateBooking;
using Hotel.Application.Features.Room.CreateRoom;
using Hotel.Application.Features.Room.UpdateRoom;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Hotel.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RoomController : ControllerBase
    {
        private IMediator _mediator;
        public RoomController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "CreateRoom")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateBooking([FromBody] CreateRoomCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut(Name = "UpdateRoom")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateRoom([FromBody] UpdateRoomCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
