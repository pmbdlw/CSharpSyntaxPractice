using CodeFirstLearning.Domain.Entities;

namespace CodeFirstLearning.Application.Interfaces;

public interface IPostService
{
    Task<Post?> GetPostByIdAsync(long id);
    Task<IEnumerable<Post>> GetAllPostsAsync();
    Task CreatePostAsync(Post post);
}