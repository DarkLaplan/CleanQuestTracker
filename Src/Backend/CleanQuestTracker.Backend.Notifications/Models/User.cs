namespace CleanQuestTracker.Backend.Notifications.Models;

/// <summary>
/// Dto model of single user of application.
/// </summary>
public class User
{
    /// <summary>
    /// Gets or sets name of the user.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets email address of the user.
    /// </summary>
    public string? Email { get; set; }
}
