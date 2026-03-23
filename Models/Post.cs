using System.Collections.Generic;

namespace blogsite.Models;

public class Author
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Name => $"{LastName}, {FirstName}";
    public List<Post> Posts { get; set; } = new();
}

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Post> Posts { get; set; } = new();
}

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public string Excerpt => Content.Length > 100 ? Content.Substring(0, 100) + "..." : Content;
    public int AuthorId { get; set; }
    public Author? Author { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}
