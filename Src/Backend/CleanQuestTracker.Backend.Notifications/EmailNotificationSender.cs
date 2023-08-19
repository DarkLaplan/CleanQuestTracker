using CleanQuestTracker.Backend.Notifications.Models;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;

namespace CleanQuestTracker.Backend.Notifications;

/// <summary>
/// Email notification sender. 
/// </summary>
public sealed class EmailNotificationSender : INotificationSender
{
    private readonly ILogger<EmailNotificationSender> _logger;
    private readonly IOptions<EmailSenderSettings> _emailSenderOptions;

    /// <summary>
    /// Initializes a new instance of the <see cref="EmailNotificationSender"/> class.
    /// </summary>
    /// <param name="logger">Logger.</param>
    /// <param name="emailSenderOptions"></param>
    public EmailNotificationSender(ILogger<EmailNotificationSender> logger, IOptions<EmailSenderSettings> emailSenderOptions)
    {
        _logger = logger;
        _emailSenderOptions = emailSenderOptions;
    }

    /// <inheritdoc />
    public async Task<bool> SendNotificationAsync(Notification notification)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(_emailSenderOptions.Value.SenderName, _emailSenderOptions.Value.SenderEmailAddress));
        message.To.Add(new MailboxAddress(notification.User?.Name, notification.User?.Email));
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
            _logger.LogError(ex, "Email sending attempt failed unexpectedly");
            return false;
        }

        // Task je dostupny.
        // Warning pro uz prirazeny task.
        // Error Jsi kokot takze mas - points.

        return true;
    }
}
