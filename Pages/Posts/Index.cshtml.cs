using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using blogsite.Data;
using blogsite.Models;

namespace blogsite.Pages_Posts
{
    public class IndexModel : PageModel
    {
        private readonly blogsite.Data.BlogContext _context;

        public IndexModel(blogsite.Data.BlogContext context)
        {
            _context = context;
        }

        public IList<Post> Post { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Post = await _context.Posts
                .Include(p => p.Author)
                .Include(p => p.Category)
                .ToListAsync();
        }
    }
}
