namespace BlogApp.Models.Post
{
    public class EditPostRequest
    {
        public int idPost { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
