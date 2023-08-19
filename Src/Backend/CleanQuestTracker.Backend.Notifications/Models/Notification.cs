namespace CleanQuestTracker.Backend.Notifications.Models
{
    public class Notification
    {
        public string NotificationType { get; set; }

        public string Message { get; set; }

        public User User { get; set; }
    }
}