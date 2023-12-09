using AutoMapper;
using CleanArchitecture.Aplication.Exceptions;
using Hotel.Application.Contracts.Persistence;
using Hotel.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Hotel.Application.Features.Hotel.Commands.UpdateHotel
{
    public class UpdateHotelCommandHandler : IRequestHandler<UpdateHotelCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateHotelCommandHandler> _logger;

        public UpdateHotelCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateHotelCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Handle(UpdateHotelCommand request, CancellationToken cancellationToken)
        {
            var hotelToUpdate = await _unitOfWork.HotelRepository.GetByIdAsync(request.Id);
            if (hotelToUpdate == null)
            {
                _logger.LogError($"Hotel id not found {request.Id}");
                throw new NotFoundException(name: nameof(HotelC), request.Id);
            }

            _mapper.Map(request, hotelToUpdate, typeof(UpdateHotelCommand), typeof(HotelC));
            _unitOfWork.HotelRepository.UpdateEntity(hotelToUpdate);
            await _unitOfWork.Complete();

            _logger.LogInformation($"The operation was successful updating the hotel {request.Id}");
        }
    }
}
