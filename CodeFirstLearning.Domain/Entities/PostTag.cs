namespace CodeFirstLearning.Domain.Entities;

public class PostTag
{
    public long PostId { get; set; }
    public int TagId { get; set; }

    public Post Post { get; set; }
    public Tag Tag { get; set; }
}