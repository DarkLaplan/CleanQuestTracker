using CleanQuestTracker.Backend.Notifications.Models;

namespace CleanQuestTracker.Backend.Notifications;

/// <summary>
/// Contains functionality for notification sender object.
/// </summary>
public interface INotificationSender
{
    /// <summary>
    /// Sends notification to specific user.
    /// </summary>
    /// <param name="notificationToSend">Notification which should be sent.</param>
    /// <returns>Value indicating whether success of the operation.</returns>
    Task<bool> SendNotificationAsync(Notification notificationToSend);
}
