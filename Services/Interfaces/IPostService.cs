using BlogApp.Entities;
using BlogApp.Models.Post;

namespace BlogApp.Services.Interfaces
{
    public interface IPostService
    {
        Task<Post> CreatePostAsync(int userId, CreatePostRequest request);
        Task<Post> EditPostAsync(EditPostRequest request);
        Task DeletePostAsync(int postId);
        Task<IEnumerable<Post>> GetPostsAsync();
        Task<Post> GetPostByIdAsync(int id);
    }
}
