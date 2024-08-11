using CodeFirstLearning.Domain.Entities;
using CodeFirstLearning.Infrastructure.Repositories;
using MediatR;

namespace CodeFirstLearning.Application.Commands;

public class CreatePostCommandHandler(IPostRepository postRepository) : IRequestHandler<CreatePostCommand, Post>
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

        await postRepository.AddAsync(post);
        await postRepository.SaveChangesAsync();
        return post;
    }
}