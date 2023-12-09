using Hotel.Application.Features.Booking.Queries.GetBookings;
using Hotel.Application.Features.Bookings.Commands.CreateBooking;
using Hotel.Application.Features.Bookings.Commands.UpdateBooking;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Hotel.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BookingController : ControllerBase
    {
        private IMediator _mediator;
        public BookingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "CreateBooking")]
        [Authorize]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateBooking([FromBody] CreateBookingCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut(Name = "UpdateBooking")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateBooking([FromBody] UpdateBookingCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpGet("{userId}", Name = "GetBookings")]
        [Authorize]
        [ProducesResponseType(typeof(IEnumerable<BookingsVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<BookingsVm>>> GetVideosByIdUser(string userId)
        {
            var query = new GetBookingQuery(userId);
            var bookings = await _mediator.Send(query);
            return Ok(bookings);
        }
    }
}
