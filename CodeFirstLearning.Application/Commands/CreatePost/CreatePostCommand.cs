using CodeFirstLearning.Domain.Entities;
using MediatR;

namespace CodeFirstLearning.Application.Commands;

public class CreatePostCommand: IRequest<Post>
{
    public string Title { get; set; }
    public string Content { get; set; }
    public int AuthorId { get; set; }
    
    public int CategoryId{ get; set; }
    
    public bool IsPublished { get; set; }

    public CreatePostCommand(string title, string content, int authorId,int categoryId,bool isPublished)
    {
        Title = title;
        Content = content;
        AuthorId = authorId;
        CategoryId = categoryId;
        IsPublished = isPublished;
    }
}