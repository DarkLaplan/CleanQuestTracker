namespace CleanQuestTracker.Backend.Notifications.Models;

public sealed class EmailSenderSettings
{
    public string SenderEmailAddress { get; set; }

    public string SenderName { get; set; }

    public string SmtpUserName { get; set; }

    public string SmtpPassword { get; set; }

    public string SmtpServer { get; set; }

    public int SmtpPort { get; set; }
}
