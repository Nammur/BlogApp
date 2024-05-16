using BlogApp.Entities;

namespace BlogApp.Services.Interfaces
{
    public interface IAuthService
    {
        Task<User> RegisterAsync(string username, string password);
        Task<User> LoginAsync(string username, string password);
    }
}
