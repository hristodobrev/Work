using Microsoft.AspNet.SignalR;

namespace PushNotifications
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            Clients.All.addNewMessageToPage(name, message);
        }

        public static void BroadCastMessage(string name, string message)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
            context.Clients.All.addNewMessageToPage(name, message);
        }
    }
}