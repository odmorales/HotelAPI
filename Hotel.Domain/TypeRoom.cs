using Hotel.Domain.Common;

namespace Hotel.Domain
{
    public class TypeRoom: BaseDomainModel
    {
        public string? Name { get; set; }
        public bool State { get; set; }
    }
}
