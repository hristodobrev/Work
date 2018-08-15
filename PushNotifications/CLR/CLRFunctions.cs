using Microsoft.SqlServer.Server;
using PushNotifications.Models;
using System.Data.SqlTypes;

namespace CLR
{
    public class CLRFunctions
    {
        [SqlFunction]
        public static SqlString Test(SqlString text)
        {
            return text + " [modified]";
        }

        [SqlFunction]
        public static void SendNotification(SqlString name, SqlString message)
        {
            NotificationService.BroadcastMessage(name.ToString(), message.ToString());
        }
    }
}