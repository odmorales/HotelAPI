using Hotel.Application.Features.Hotel.Commands.CreateHotel;
using Hotel.Application.Features.Hotel.Commands.UpdateHotel;
using Hotel.Application.Features.Hotel.Queries.GetHotelsWithBooking;
using Hotel.Application.Features.Hotel.Queries.GetListHotels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Hotel.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class HotelController : ControllerBase
    {
        private IMediator _mediator;

        public HotelController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "CreateHotel")]
        [Authorize]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateHotel([FromBody] CreateHotelCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut(Name = "UpdateHotel")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateHotel([FromBody] UpdateHotelCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpGet(Name = "GetAllHotelsAvalible")]
        //[Authorize]
        [ProducesResponseType(typeof(IEnumerable<HotelsVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<HotelsVm>>> GetAllHotelsAvalible()
        {
            var query = new GetHotelsListQuery();
            var hotels = await _mediator.Send(query);
            return Ok(hotels);
        }

        [HttpGet("{arrivalDate}, {departureDate},{number},{townId}", Name = "GetHotelBookings")]
        //[Authorize]
        [ProducesResponseType(typeof(IEnumerable<HotelsBokkingVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<HotelsBokkingVm>>> GetHotelBookings(DateTime arrivalDate, DateTime departureDate, int number, int townId)
        {
            var query = new GetHotelsBookingQuery(arrivalDate, departureDate, number, townId);
            var hotels = await _mediator.Send(query);
            return Ok(hotels);
        }
    }
}
