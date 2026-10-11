using System;
using System.Collections.Generic;
using System.Text;
using GloboTicket.TicketManagement.Application.Contracts.Infrastructure;
using GloboTicket.TicketManagement.Application.Models;
using Microsoft.Extensions.Logging;

namespace GloboTicket.TicketManagement.Infrastructure.Mail
{
    public class EmailService : IEmailService
    {
        private readonly ILogger<EmailService> _logger;

        public EmailService(ILogger<EmailService> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> SendEmail(Email email)
        {
            _logger.LogInformation(
                "Email notification: recipient {Recipient}; subject {Subject}; body {Body}",
                email.To,
                email.Subject,
                email.Body);

            return await Task.FromResult(true);
        }
    }
}
