namespace CodeFirstLearning.Domain.Entities;

public class Post
{
    public long PostId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public long AuthorId { get; set; }
    public int? CategoryId { get; set; }
    public DateTime PublishedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public bool IsPublished { get; set; }

    public Author Author { get; set; }
    public Category Category { get; set; }
}