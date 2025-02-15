using DiscussionForum.Data;
using DiscussionForum.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DiscussionForum.Controllers
{
    public class DiscussionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DiscussionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DiscussionController
        public async Task<IActionResult> Index()
        {
            var discussions = await _context.Discussions.Include(d => d.Comments).ToListAsync();
            return View(discussions);
        }

        // GET: DiscussionController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var discussion = await _context.Discussions
                .Include(d => d.Comments)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (discussion == null)
            {
                return NotFound();
            }
            return View(discussion);
        }

        // GET: DiscussionController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DiscussionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Content,ImagePath")] Discussion discussion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(discussion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(discussion);
        }

        // GET: DiscussionController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var discussion = await _context.Discussions.FindAsync(id);
            if (discussion == null)
            {
                return NotFound();
            }
            return View(discussion);
        }

        // POST: DiscussionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Content,ImagePath")] Discussion discussion)
        {
            if (id != discussion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(discussion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiscussionExists(discussion.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(discussion);
        }

        // GET: DiscussionController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var discussion = await _context.Discussions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (discussion == null)
            {
                return NotFound();
            }
            return View(discussion);
        }

        // POST: DiscussionController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var discussion = await _context.Discussions.FindAsync(id);
            _context.Discussions.Remove(discussion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiscussionExists(int id)
        {
            return _context.Discussions.Any(e => e.Id == id);
        }
    }
}
