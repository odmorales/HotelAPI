

namespace Hotel.Domain
{
    public class Town
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int State { get; set; }
        public virtual Deparment? Deparment { get; set; }
        public int DeparmentId { get; set; }
    }
}
