using Hotel.Domain;
using Hotel.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Infrastructure.Persistence
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        {

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainModel>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "system";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "system";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HotelC>()
                .HasOne(h => h.Town)
                .WithMany()
                .HasForeignKey(h => h.TownId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<HotelC>()
                .HasOne(h => h.Deparment)
                .WithMany()
                .HasForeignKey(h => h.DeparmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BookingHotel>()
                .HasOne(h => h.RoomHotel)
                .WithMany()
                .HasForeignKey(h => h.RoomHotelId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<BookingHotel> BookingHotels { get; set; }
        //public DbSet<BookingDetail> BookingDetails { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<HotelC> HotelCs { get; set; }
        public DbSet<RoomHotel> RoomHotels { get; set; }
        public DbSet<TypeRoom> TypeRooms { get; set; }
        public DbSet<EmergencyContact> EmergencyContacts { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Deparment> Deparments { get; set; }
        public DbSet<LocationRoom> LocationRooms { get; set; }
        public DbSet<StateBooking> StateBookings { get; set; }

    }
}
