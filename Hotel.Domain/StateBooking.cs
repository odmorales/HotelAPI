using Hotel.Domain.Common;

namespace Hotel.Domain
{
    public class StateBooking : BaseDomainModel
    {
        public int State { get; set; }
        public string? Description { get; set; }
        public bool Available { get; set; }
    }
}
