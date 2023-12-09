using AutoMapper;
using CleanArchitecture.Aplication.Exceptions;
using Hotel.Application.Contracts.Infraestructure;
using Hotel.Application.Contracts.Persistence;
using Hotel.Application.Models;
using Hotel.Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using System.IO;

namespace Hotel.Application.Features.Bookings.Commands.CreateBooking
{
    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateBookingCommand> _logger;

        public CreateBookingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IEmailService emailService, ILogger<CreateBookingCommand> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<int> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var bookingEntity = Mapper(request);
            _unitOfWork.Repository<BookingHotel>().AddEntity(bookingEntity);
            await UpdateRoomReserved(request.RoomHotelId);

            var result = await _unitOfWork.Complete();

            if (result <= 0)
            {
                throw new Exception("Error");
            }

            _logger.LogInformation($"{bookingEntity.Id}");
            await SendEmail(bookingEntity);

            return bookingEntity.Id;
        }

        private BookingHotel Mapper(CreateBookingCommand request)
        {
            return new BookingHotel
            {
                ArrivalDate = request.ArrivalDate,
                DepartureDate = request.DepartureDate,
                HotelCId = request.HotelCId,
                RoomHotelId = request.RoomHotelId,
                StateBookingId = request.StateBookingId,
                UserId = request.UserId,
                EmergencyContact = new EmergencyContact
                {
                    Names = request.EmergencyContact.Names,
                    PhoneNumber = request.EmergencyContact.PhoneNumber
                },
                Guests =  request.Guests.Select(x => new Guest
                {
                    Name = x.Name,
                    LastName = x.LastName,
                    PhoneNumber= x.PhoneNumber,
                    BirthDate = x.BirthDate,
                    DocumentNumber = x.DocumentNumber,
                    DocumentTypeId = x.DocumentTypeId,
                    GenderId = x.GenderId,
                    Email = x.Email,
                }).ToList()
            };
        }

        private async Task UpdateRoomReserved(int Id)
        {
            var roomToUpdate = await _unitOfWork.RoomRepository.GetByIdAsync(Id);
            if (roomToUpdate == null)
            {
                _logger.LogError($"Room id not found {Id}");
                throw new NotFoundException(name: nameof(RoomHotel), Id);
            }
            roomToUpdate.Available = false;
        }

        private async Task SendEmail(BookingHotel booking)
        {
            var email = new Email
            {
                To = "odmorales05@gmail.com",
                Body = "Booking has been created correctly",
                Subject = "Alert Message"
            };
            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Errores enviendo el email de {booking.Id}");
            }
        }
    }

}
