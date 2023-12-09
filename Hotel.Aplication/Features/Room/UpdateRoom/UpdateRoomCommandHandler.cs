
using AutoMapper;
using CleanArchitecture.Aplication.Exceptions;
using Hotel.Application.Contracts.Persistence;
using Hotel.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Hotel.Application.Features.Room.UpdateRoom
{
    public class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateRoomCommandHandler> _logger;

        public UpdateRoomCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateRoomCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
        {
            var roomToUpdate = await _unitOfWork.RoomRepository.GetByIdAsync(request.Id);
            if (roomToUpdate == null)
            {
                _logger.LogError($"Room id not found {request.Id}");
                throw new NotFoundException(name: nameof(RoomHotel), request.Id);
            }

            _mapper.Map(request, roomToUpdate, typeof(UpdateRoomCommand), typeof(RoomHotel));
            _unitOfWork.RoomRepository.UpdateEntity(roomToUpdate);
            await _unitOfWork.Complete();

        }
    }
}
