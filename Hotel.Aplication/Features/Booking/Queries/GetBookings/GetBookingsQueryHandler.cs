using AutoMapper;
using Hotel.Application.Contracts.Persistence;
using MediatR;

namespace Hotel.Application.Features.Booking.Queries.GetBookings
{
    public class GetBookingsQueryHandler : IRequestHandler<GetBookingQuery, List<BookingsVm>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBookingsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<BookingsVm>> Handle(GetBookingQuery request, CancellationToken cancellationToken)
        {
            var bookingList = await _unitOfWork.BookingRepository.GetBookingsByUserId(request._UserId);
            return bookingList.ToList();
        }
    }
}
