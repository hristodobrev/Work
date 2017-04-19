using Microsoft.Web.WebSockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVCExamples.Controllers
{
    public class ChatController : Controller
    {
        public HttpResponseMessage Get(string username)
        {
            System.Web.HttpContext.Current.AcceptWebSocketRequest(new ChatWebSocketHandler(username));
            return new HttpResponseMessage(HttpStatusCode.SwitchingProtocols);
        }

        class ChatWebSocketHandler : WebSocketHandler
        {
            private static WebSocketCollection chatClients = new WebSocketCollection();
            private string username;

            public ChatWebSocketHandler(string username)
            {
                this.username = username;
            }

            public override void OnOpen()
            {
                chatClients.Add(this);
            }

            public override void OnMessage(string message)
            {
                chatClients.Broadcast(this.username + ": " + message);
            }
        }
    }
}