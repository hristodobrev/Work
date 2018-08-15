namespace PushNotifications.Models
{
    public class NotificationService
    {
        public static void BroadcastMessage(string name, string message)
        {
            ChatHub.BroadCastMessage(name, message);
        }
    }
}