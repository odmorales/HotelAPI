using CleanArchitecture.Aplication.Exceptions;
using Hotel.Application.Contracts.Persistence;
using Hotel.Application.Features.Hotel.Commands.UpdateHotel;
using Hotel.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Hotel.Application.Features.Bookings.Commands.UpdateBooking
{
    public class UpdateBookingCommandHandler : IRequestHandler<UpdateBookingCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UpdateHotelCommandHandler> _logger;

        public UpdateBookingCommandHandler(IUnitOfWork unitOfWork, ILogger<UpdateHotelCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
        {
            var bookingToUpdate = await _unitOfWork.BookingRepository.GetByIdAsync(request.Id);

            if (bookingToUpdate == null)
            {
                _logger.LogError($"Hotel id not found {request.Id}");
                throw new NotFoundException(name: nameof(HotelC), request.Id);
            }

            bookingToUpdate.StateBookingId = request.StateBookingId;
            _unitOfWork.BookingRepository.UpdateEntity(bookingToUpdate);
            await _unitOfWork.Complete();

            _logger.LogInformation($"The operation was successful updating the booking {request.Id}");
        }
    }
}
