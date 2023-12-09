using Hotel.Domain.Common;

namespace Hotel.Domain
{
    public class EmergencyContact : BaseDomainModel
    {
        public string? Names { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
