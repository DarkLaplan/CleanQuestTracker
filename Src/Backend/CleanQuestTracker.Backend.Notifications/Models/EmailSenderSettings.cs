namespace CleanQuestTracker.Backend.Notifications.Models;

/// <summary>
/// Dto model for email sender settings.
/// </summary>
public sealed class EmailSenderSettings
{
    /// <summary>
    /// Gets or sets sender's email address.
    /// </summary>
    public string? SenderEmailAddress { get; set; }

    /// <summary>
    /// Gets or sets sender's name.
    /// </summary>
    public string? SenderName { get; set; }

    /// <summary>
    /// Gets or sets STMP user's name.
    /// </summary>
    public string? SmtpUserName { get; set; }

    /// <summary>
    /// Gets or sets STMP  password.
    /// </summary>
    public string? SmtpPassword { get; set; }

    /// <summary>
    /// Gets or sets STMP server address.
    /// </summary>
    public string? SmtpServer { get; set; }

    /// <summary>
    /// Gets or sets STMP port.
    /// </summary>
    public int SmtpPort { get; set; }
}
