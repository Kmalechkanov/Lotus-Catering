﻿namespace AnisMasterpieces.Services.Messaging
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class NullMessageSender : IEmailSender
    {
        public Task SendEmailAsync(
            string from, 
            string fromName, 
            string to, 
            string subject,
            string htmlContent, 
            IEnumerable<EmailAttachment> attachment = null)
        {
            return Task.CompletedTask;
        }
    }
}
