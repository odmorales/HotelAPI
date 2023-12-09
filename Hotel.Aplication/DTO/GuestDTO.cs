namespace Hotel.Application.DTO
{
    public class GuestDTO
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int GenderId { get; set; }
        public string? GenderDescription { get; set; }
        public string? DocumentType { get; set; }
        public string? DocumentNumber { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
