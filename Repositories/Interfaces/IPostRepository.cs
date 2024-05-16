using BlogApp.Entities;

namespace BlogApp.Services.Interfaces
{
    public interface IPostRepository
    {
        Task<Post> GetPostByIdAsync(int id);
        Task<IEnumerable<Post>> GetAllPostsAsync();
        Task<IEnumerable<Post>> GetPostsUserAsync(int idUser);
        Task AddPostAsync(Post post);
        Task UpdatePostAsync(Post post);
        Task DeletePostAsync(int id);
    }
}
