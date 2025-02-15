namespace DiscussionForum.Models
{
    public class Comment
    {

        public int Id { get; set; }
        public int DiscussionId { get; set; }
        public string Content { get; set; } = string.Empty;  // Initialized to empty string
        public string Author { get; set; } = "User";           // Default value
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        // Marking the navigation property as nullable avoids the warning
        public Discussion? Discussion { get; set; }
    }
}
