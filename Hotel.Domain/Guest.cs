using Hotel.Domain.Common;

namespace Hotel.Domain
{
    public class Guest : BaseDomainModel
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public virtual Gender? Gender { get; set; }
        public int GenderId { get; set; }
        public virtual DocumentType? DocumentType { get; set; }
        public int DocumentTypeId { get; set; }
        public virtual BookingHotel? BookingHotel { get; set; }
        public int BookingHotelId { get; set; }
        public string? DocumentNumber { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set;}
    }
}
