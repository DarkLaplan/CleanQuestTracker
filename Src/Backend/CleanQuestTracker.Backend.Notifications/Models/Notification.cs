namespace CleanQuestTracker.Backend.Notifications.Models;

/// <summary>
/// Dto model of single notification.
/// </summary>
public class Notification
{
    /// <summary>
    /// Gets or sets identification of notification type.
    /// </summary>
    public string? NotificationType { get; set; }

    /// <summary>
    /// Gets or sets message of the notification.
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    /// Gets or sets information about the user associated with the given notification.
    /// </summary>
    public User? User { get; set; }
}