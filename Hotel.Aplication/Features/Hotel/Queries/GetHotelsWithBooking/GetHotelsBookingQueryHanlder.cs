
using Hotel.Application.Contracts.Persistence;
using MediatR;

namespace Hotel.Application.Features.Hotel.Queries.GetHotelsWithBooking
{
    public class GetHotelsBookingQueryHanlder : IRequestHandler<GetHotelsBookingQuery, List<HotelsBokkingVm>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetHotelsBookingQueryHanlder(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<HotelsBokkingVm>> Handle(GetHotelsBookingQuery request, CancellationToken cancellationToken)
        {
            var bookingList = await _unitOfWork.HotelRepository.GetAllHotelsBookings(request._ArrivalDate, request._DepartureDate,
                    request._Amount, request._TownId);
            return bookingList.ToList();
        }
    }
}
