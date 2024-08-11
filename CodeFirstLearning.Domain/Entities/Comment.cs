namespace CodeFirstLearning.Domain.Entities;

public class Comment
{
    public int CommentId { get; set; }
    public long PostId { get; set; }
    public long? UserId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Post Post { get; set; }
    public User User { get; set; }
}