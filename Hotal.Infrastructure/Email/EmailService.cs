﻿
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using Hotel.Application.Contracts.Infraestructure;
using Hotel.Application.Models;

namespace CleanArchitecture.Infrastructure.Email
{
    public class EmailService : IEmailService
    {
        public EmailSettings _emailSettings { get; }
        public ILogger<EmailService> _logger { get; }

        public EmailService(IOptions<EmailSettings> emailSettings, ILogger<EmailService> logger)
        {
            _emailSettings = emailSettings.Value;
            _logger = logger;
        }

        public async Task<bool> SendEmail(Hotel.Application.Models.Email email)
        {
            var client = new SendGridClient(_emailSettings.ApiKey);

            var subject = email.Subject;
            var to = new EmailAddress(email.To);
            var emailBody = email.Body;

            var from = new EmailAddress
            {
                Email = _emailSettings.FromAddress,
                Name = _emailSettings.FromName
            };

            var senGridMessage = MailHelper.CreateSingleEmail(from, to, subject, emailBody, emailBody);
            var respone = await client.SendEmailAsync(senGridMessage);

            if (respone.StatusCode == System.Net.HttpStatusCode.Accepted || respone.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }

            _logger.LogError("El email no pudo enviarse, existen errores");
            return false;
        }
    }
}
