using Hotel.Application.Models;

namespace Hotel.Application.Contracts.Infraestructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
