namespace CodeFirstLearning.Domain.Entities;
public enum AuthorType
{
    User,
    SpecialContributor
}
public class Author
{
    public long AuthorId { get; set; }
    public AuthorType AuthorType { get; set; }
    public int AuthorRefId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Bio { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}