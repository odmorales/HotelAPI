using AutoMapper;
using Hotel.Application.DTO;
using Hotel.Application.Features.Bookings.Commands.CreateBooking;
using Hotel.Application.Features.Hotel.Commands.CreateHotel;
using Hotel.Application.Features.Hotel.Commands.UpdateHotel;
using Hotel.Application.Features.Room.CreateRoom;
using Hotel.Application.Features.Room.UpdateRoom;
using Hotel.Domain;
using System.Runtime.ConstrainedExecution;

namespace Hotel.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateHotelCommand, HotelC>();

            CreateMap<UpdateHotelCommand, HotelC>();

            CreateMap<CreateBookingCommand, BookingHotel>();

            CreateMap<CreateRoomCommand, RoomHotel>();

            CreateMap<UpdateRoomCommand, RoomHotel>();
        }
    }
}
