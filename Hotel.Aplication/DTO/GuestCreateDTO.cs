
namespace Hotel.Application.DTO
{
    public class GuestCreateDTO
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int GenderId { get; set; }
        public int DocumentTypeId { get; set; }
        public string? DocumentNumber { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
