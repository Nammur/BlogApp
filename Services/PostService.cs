using BlogApp.Entities;
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

        public async Task<Post> CreatePostAsync(int userId, string title, string content)
        {
            var post = new Post { Title = title, Content = content, CreatedAt = DateTime.UtcNow, UserId = userId };
            await _postRepository.AddPostAsync(post);
            await _notificationService.NotifyNewPostAsync(post);
            return post;
        }

        public async Task<Post> EditPostAsync(int postId, string title, string content)
        {
            var post = await _postRepository.GetPostByIdAsync(postId);
            if (post != null)
            {
                post.Title = title;
                post.Content = content;
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
    }
}
