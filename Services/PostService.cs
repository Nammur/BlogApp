using BlogApp.Entities;
using BlogApp.Models.Post;
using BlogApp.Services.Interfaces;

namespace BlogApp.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly INotificationService _notificationService;

        public PostService(IPostRepository postRepository, INotificationService notificationService)
        {
            _postRepository = postRepository;
            _notificationService = notificationService;
        }

        public async Task<Post> CreatePostAsync(int userId, CreatePostRequest request)
        {
            var post = new Post {Title = request.Title, Content = request.Content, CreatedAt = DateTime.UtcNow, UserId = userId };
            await _postRepository.AddPostAsync(post);
            await _notificationService.NotifyNewPostAsync(post);
            return post;
        }

        public async Task<Post> EditPostAsync(EditPostRequest request)
        {
            var post = await _postRepository.GetPostByIdAsync(request.idPost);
            if (post != null)
            {
                post.Title = request.Title;
                post.Content = request.Content;
                await _postRepository.UpdatePostAsync(post);
            }
            return post;
        }

        public async Task DeletePostAsync(int postId)
        {
            await _postRepository.DeletePostAsync(postId);
        }

        public async Task<IEnumerable<Post>> GetPostsAsync()
        {
            return await _postRepository.GetAllPostsAsync();
        }

        public async Task<Post> GetPostByIdAsync(int id) { 
            return await _postRepository.GetPostByIdAsync(id);
        }
    }
}
