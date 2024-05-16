using BlogApp.Entities;
using BlogApp.Hubs;
using BlogApp.Services.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace BlogApp.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public NotificationService(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task NotifyNewPostAsync(Post post)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveNotification", post);
        }
    }
}
