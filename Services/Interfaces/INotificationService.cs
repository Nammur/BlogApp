using BlogApp.Entities;

namespace BlogApp.Services.Interfaces
{
    public interface INotificationService
    {
        Task NotifyNewPostAsync(Post post);
    }
}
