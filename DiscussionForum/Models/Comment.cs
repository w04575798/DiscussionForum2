namespace DiscussionForum.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int DiscussionId { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public Discussion Discussion { get; set; }
    }

}
