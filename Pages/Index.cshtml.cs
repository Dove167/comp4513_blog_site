using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using blogsite.Data;
using blogsite.Models;

namespace blogsite.Pages;

public class IndexModel : PageModel
{
    private readonly BlogContext _context;

    public IndexModel(BlogContext context)
    {
        _context = context;
    }
    
    public List<Post> Posts { get; set; } = new();
    public Dictionary<Category, List<Post>> PostsByCategory { get; set; } = new();
    
    public async Task OnGetAsync()
    {
        Posts = await _context.Posts
            .Include(p => p.Category)
            .OrderByDescending(p => p.CreatedAt)
            .ToListAsync();

        PostsByCategory = Posts
            .Where(p => p.Category != null)
            .GroupBy(p => p.Category!)
            .ToDictionary(g => g.Key, g => g.ToList());
    }
}
