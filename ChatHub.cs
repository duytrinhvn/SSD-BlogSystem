﻿using BlogSystem.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSystem
{
    public class ChatHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync(
                "ReceiveMessage",
                "Blog System",
                DateTimeOffset.UtcNow,
                "Greeting! How are you today?");

            await base.OnConnectedAsync();
        }

        public async Task SendMessage(string name, string text)
        {
            var message = new ChatMessage
            {
                SenderName = name,
                Text = text,
                SentAt = DateTimeOffset.UtcNow
            };

            // Broadcast to all clients
            await Clients.All.SendAsync(
                "ReceiveMessage",
                message.SenderName,
                message.SentAt,
                message.Text);
        }
    }
}
