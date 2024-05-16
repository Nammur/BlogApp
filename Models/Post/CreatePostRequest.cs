namespace BlogApp.Models.Post
{
    public class CreatePostRequest
    {
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
