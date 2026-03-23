using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using blogsite.Data;
using blogsite.Models;

namespace blogsite.Pages_Authors
{
    public class DetailsModel : PageModel
    {
        private readonly blogsite.Data.BlogContext _context;

        public DetailsModel(blogsite.Data.BlogContext context)
        {
            _context = context;
        }

        public Author Author { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await _context.Authors.FirstOrDefaultAsync(m => m.Id == id);

            if (author is not null)
            {
                Author = author;

                return Page();
            }

            return NotFound();
        }
    }
}
