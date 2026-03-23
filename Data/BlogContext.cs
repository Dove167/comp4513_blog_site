using Microsoft.EntityFrameworkCore;
using blogsite.Models;

namespace blogsite.Data;

public class BlogContext : DbContext
{
    public BlogContext(DbContextOptions<BlogContext> options)
         : base(options) { }

    public DbSet<Post> Posts { get; set; } = default!;
    public DbSet<Author> Authors { get; set; } = default!;
    public DbSet<Category> Categories { get; set; } = default!;
}
