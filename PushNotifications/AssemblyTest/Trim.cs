using PushNotifications.Models;
using System.Data.SqlTypes;

public partial class UserDefinedFunctions
{
    [Microsoft.SqlServer.Server.SqlFunction]
    public void brd_cst_msg(SqlString name, SqlString message)
    {
        NotificationService.BroadcastMessage(name.ToString(), message.ToString());
    }
}