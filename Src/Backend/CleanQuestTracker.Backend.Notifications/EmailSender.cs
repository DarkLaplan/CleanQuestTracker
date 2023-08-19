using CleanQuestTracker.Backend.Notifications.Models;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace CleanQuestTracker.Backend.Notifications;

public sealed class EmailNotificationSender : INotificationSender
{
    private readonly IOptions<EmailSenderSettings> _emailSenderOptions;

    public EmailNotificationSender(IOptions<EmailSenderSettings> emailSenderOptions)
    {
        _emailSenderOptions = emailSenderOptions;
    }

    public async Task<bool> SendNotificationAsync(Notification notification)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(_emailSenderOptions.Value.SenderName, _emailSenderOptions.Value.SenderEmailAddress));
        message.To.Add(new MailboxAddress(notification.User.Name, notification.User.Email));
        message.Subject = notification.NotificationType;

        message.Body = new TextPart("plain")
        {
            Text = notification.Message
        };

        using var client = new SmtpClient();
        try
        {
            await client.ConnectAsync(_emailSenderOptions.Value.SmtpServer, _emailSenderOptions.Value.SmtpPort, false);

            // Note: only needed if the SMTP server requires authentication
            await client.AuthenticateAsync(_emailSenderOptions.Value.SmtpUserName, _emailSenderOptions.Value.SmtpPassword);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
        catch (Exception ex)
        {
            return false;
        }

        // Task je dostupny.
        // Warning pro uz prirazeny task.
        // Error Jsi kokot takze mas - points.

        return true;
    }
}
