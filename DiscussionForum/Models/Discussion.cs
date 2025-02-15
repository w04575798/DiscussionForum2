namespace DiscussionForum.Models
{
    public class Discussion
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;  // Initialized to empty string
        public string Content { get; set; } = string.Empty;  // Initialized to empty string
        public string ImagePath { get; set; } = string.Empty; // For image upload, initialized to empty string
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
