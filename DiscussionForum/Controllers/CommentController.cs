using DiscussionForum.Data;
using DiscussionForum.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DiscussionForum.Controllers
{
    public class CommentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CommentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(int discussionId, string content)
        {
            var comment = new Comment { DiscussionId = discussionId, Content = content };
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Discussion", new { id = discussionId });
        }
    }
}
