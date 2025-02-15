namespace DiscussionForum.Models
{
    public class Discussion
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; } // For image upload
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public List<Comment> Comments { get; set; } = new List<Comment>();
    }

}
