
using Hotel.Application.Contracts.Persistence;
using MediatR;

namespace Hotel.Application.Features.Hotel.Queries.GetListHotels
{
    public class GetHotelsListQueryHandler : IRequestHandler<GetHotelsListQuery, List<HotelsVm>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetHotelsListQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<HotelsVm>> Handle(GetHotelsListQuery request, CancellationToken cancellationToken)
        {
            var bookingList = await _unitOfWork.HotelRepository.GetAllHotelsAvailable();
            return bookingList.ToList();
        }
    }


}
