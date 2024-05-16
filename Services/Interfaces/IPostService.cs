using BlogApp.Entities;

namespace BlogApp.Services.Interfaces
{
    public interface IPostService
    {
        Task<Post> CreatePostAsync(int userId, string title, string content);
        Task<Post> EditPostAsync(int postId, string title, string content);
        Task DeletePostAsync(int postId);
        Task<IEnumerable<Post>> GetPostsAsync();
    }
}
