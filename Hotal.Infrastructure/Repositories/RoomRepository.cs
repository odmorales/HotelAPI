using Hotel.Application.Contracts.Persistence;
using Hotel.Domain;
using Hotel.Infrastructure.Persistence;
using System;

namespace Hotel.Infrastructure.Repositories
{
    public class RoomRepository : RepositoryBase<RoomHotel>, IRoomRepository
    {
        public RoomRepository(HotelDbContext context) : base(context) { }
    }
}
