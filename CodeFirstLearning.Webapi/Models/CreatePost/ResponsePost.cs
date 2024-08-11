namespace CodeFirstLearning.Webapi.Models.CreatePost;

public class ResponsePost
{
    public long PostId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime PublishedAt { get; set; } = DateTime.UtcNow;
    public bool IsPublished { get; set; }
    public string Author { get; set; }
    public string CategoryName { get; set; }
}