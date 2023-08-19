using CleanQuestTracker.Backend.Notifications.Models;

namespace CleanQuestTracker.Backend.Notifications
{
    public interface INotificationSender
    {
        Task<bool> SendNotificationAsync(Notification notification);
    }
}
