using CodeFirstLearning.Domain.Entities;

namespace CodeFirstLearning.Infrastructure.Repositories;

public interface IPostRepository : IRepository<Post>
{
    Task<Post?> GetPostByIdAsync(long id);
    Task<IEnumerable<Post>> GetAllPostsAsync();
}