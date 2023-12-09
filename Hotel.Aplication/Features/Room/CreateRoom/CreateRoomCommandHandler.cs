using AutoMapper;
using Hotel.Application.Contracts.Persistence;
using Hotel.Application.Features.Hotel.Commands.CreateHotel;
using Hotel.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Hotel.Application.Features.Room.CreateRoom
{
    public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateHotelCommand> _logger;

        public CreateRoomCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateHotelCommand> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            var roomEntity = _mapper.Map<RoomHotel>(request);

            _unitOfWork.Repository<RoomHotel>().AddEntity(roomEntity);
            var result = await _unitOfWork.Complete();

            if (result <= 0)
            {
                throw new Exception("Could no insert the Room");
            }

            _logger.LogInformation($"Room {roomEntity.Id} was successfully created");

            return roomEntity.Id;
        }
    }
}
