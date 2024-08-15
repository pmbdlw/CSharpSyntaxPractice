using CodeFirstLearning.Domain.Entities;
using CodeFirstLearning.Infrastructure.Repositories;
using MediatR;

namespace CodeFirstLearning.Application.Commands;

public class EditPostCommandHandler(IPostRepository postRepository) : IRequestHandler<CreatePostCommand, Post>
{

    public async Task<Post> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var post = new Post
        {
            Title = request.Title,
            Content = request.Content,
            AuthorId = request.AuthorId,
            CategoryId = request.CategoryId,
            IsPublished = request.IsPublished,
            PublishedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        postRepository.Update(post);
        await postRepository.SaveChangesAsync();
        return post;
    }
}