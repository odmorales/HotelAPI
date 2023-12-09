using Hotel.Application.Contracts.Persistence;
using Hotel.Domain.Common;
using Hotel.Infrastructure.Persistence;
using System.Collections;

namespace Hotel.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private Hashtable? _repositories;
        private readonly HotelDbContext _context;
        private IHotelRepository _hotelRepository;
        private IBookingRepository _bookingRepository;
        private IRoomRepository _roomRepository;

        //private IVideoRepository _videoRepository;
        //private IStreamerRepository _streamerRepository;
        public UnitOfWork(HotelDbContext context)
        {
            _context = context;
        }

        public IHotelRepository HotelRepository => _hotelRepository ??= new HotelRepository(_context);
        public IBookingRepository BookingRepository => _bookingRepository ??= new BookingRepository(_context);
        public IRoomRepository RoomRepository => _roomRepository ??= new RoomRepository(_context);

        //public IVideoRepository VideoRepository => _videoRepository ??= new VideoRepository(_context);
        //public IStreamerRepository StreamerRepository => _streamerRepository ??= new StreamerRepository(_context);

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(RepositoryBase<>);
                var respositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                _repositories.Add(type, respositoryInstance);
            }

            return (IAsyncRepository<TEntity>)_repositories[type]!;
        }
    }
}
