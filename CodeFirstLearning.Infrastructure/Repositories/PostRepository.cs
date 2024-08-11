using CodeFirstLearning.Domain.Entities;
using CodeFirstLearning.Infrastructure.Data;
using IdGen;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstLearning.Infrastructure.Repositories;

public class PostRepository(PostDbContext context) : Repository<Post>(context), IPostRepository
{
    public async Task<Post?> GetPostByIdAsync(long id)
    {
        return await context.Posts.Include(p => p.Author).Include(c=>c.Category).FirstOrDefaultAsync(p => p.PostId == id);
    }

    public async Task<IEnumerable<Post>> GetAllPostsAsync()
    {
        return await context.Posts.ToListAsync(); //context.Posts.Include(p => p.Author).ToListAsync();
    }
    
    public new async Task AddAsync(Post entity)
    {
        var generator = new IdGenerator(0);
        entity.PostId = generator.CreateId();
        await context.Posts.AddAsync(entity);
        await context.Posts.AddAsync(entity);
    }
}