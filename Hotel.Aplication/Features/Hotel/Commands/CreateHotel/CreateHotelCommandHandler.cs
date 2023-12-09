
using AutoMapper;
using Hotel.Application.Contracts.Persistence;
using Hotel.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Hotel.Application.Features.Hotel.Commands.CreateHotel
{
    public class CreateHotelCommandHandler : IRequestHandler<CreateHotelCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateHotelCommand> _logger;

        public CreateHotelCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateHotelCommand> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(CreateHotelCommand request, CancellationToken cancellationToken)
        {
            var hotelEntity = _mapper.Map<HotelC>(request);

            _unitOfWork.Repository<HotelC>().AddEntity(hotelEntity);
            var result = await _unitOfWork.Complete();

            if(result <= 0)
            {
                throw new Exception("Could no insert the Hotel");
            }

            _logger.LogInformation($"Hotel {hotelEntity.Id} was successfully created");

            return hotelEntity.Id;
        }
    }
}
