using CodeFirstLearning.Application.Interfaces;
using CodeFirstLearning.Domain.Entities;
using CodeFirstLearning.Infrastructure.Repositories;

namespace CodeFirstLearning.Application.Services;

public class PostService(IPostRepository postRepository) : IPostService
{
    public async Task<Post?> GetPostByIdAsync(long id)
    {
        return await postRepository.GetPostByIdAsync(id);
    }

    public async Task<IEnumerable<Post>> GetAllPostsAsync()
    {
        return await postRepository.GetAllPostsAsync();
    }

    public async Task CreatePostAsync(Post post)
    {
        await postRepository.AddAsync(post);
        await postRepository.SaveChangesAsync();
    }
}