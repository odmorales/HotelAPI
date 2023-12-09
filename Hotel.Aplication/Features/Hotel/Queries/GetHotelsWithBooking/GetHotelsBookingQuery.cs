using MediatR;

namespace Hotel.Application.Features.Hotel.Queries.GetHotelsWithBooking
{
    public class GetHotelsBookingQuery: IRequest<List<HotelsBokkingVm>>
    {
        public DateTime _ArrivalDate { get; set; }
        public DateTime _DepartureDate { get; set; }
        public int _Amount { get; set; }
        public int _TownId { get; set; }

        public GetHotelsBookingQuery(DateTime arrivalDate, DateTime departureDate, int amount, int townId)
        {
            _ArrivalDate = arrivalDate;
            _DepartureDate = departureDate;
            _Amount = amount;
            _TownId = townId;
        }
    }
}
