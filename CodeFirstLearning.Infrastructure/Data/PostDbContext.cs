using CodeFirstLearning.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstLearning.Infrastructure.Data;

public class PostDbContext : DbContext
{
    public PostDbContext(DbContextOptions<PostDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Administrator> Administrators { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<PostTag> PostTags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.ApplyConfiguration(new UserConfiguration());
        // modelBuilder.ApplyConfiguration(new AdministratorConfiguration());
        // modelBuilder.ApplyConfiguration(new AuthorConfiguration());
        // modelBuilder.ApplyConfiguration(new PostConfiguration());
        // modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        // modelBuilder.ApplyConfiguration(new CommentConfiguration());
        // modelBuilder.ApplyConfiguration(new TagConfiguration());
        // modelBuilder.ApplyConfiguration(new PostTagConfiguration());
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}