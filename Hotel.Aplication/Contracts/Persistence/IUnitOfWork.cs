using Hotel.Application.Contracts.Persistence;
using Hotel.Domain.Common;

namespace Hotel.Application.Contracts.Persistence
{
    public interface IUnitOfWork: IDisposable
    {
        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel;
        IHotelRepository HotelRepository { get; }
        IBookingRepository BookingRepository { get; }
        IRoomRepository RoomRepository { get; }
        Task<int> Complete();
    }
}
