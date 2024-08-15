using CodeFirstLearning.Application.Interfaces;
using CodeFirstLearning.Application.Services;
using CodeFirstLearning.Application.Commands;
using CodeFirstLearning.Infrastructure.Data;
using CodeFirstLearning.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstLearning.Webapi.Extensions;

public static class PostSystemServiceExtension
{
    public static IServiceCollection AddPostSystemServices(this IServiceCollection services,
        ConfigurationManager config)
    {
        // Inject connection string.
        services.AddDbContext<PostDbContext>(
            options => options.UseNpgsql(config.GetConnectionString("DefaultConnection"))
        );

        // Register application services
        services.AddScoped<IPostService, PostService>();
        // services.AddScoped<IUserService, UserService>();
        // services.AddScoped<IAdministratorService, AdministratorService>();
        // services.AddScoped<IAuthorService, AuthorService>();
        // services.AddScoped<ICategoryService, CategoryService>();
        // services.AddScoped<ICommentService, CommentService>();
        // services.AddScoped<ITagService, TagService>();

        // Register repositories
        services.AddScoped<IPostRepository, PostRepository>();
        // services.AddScoped<IUserRepository, UserRepository>();
        // services.AddScoped<IAdministratorRepository, AdministratorRepository>();
        // services.AddScoped<IAuthorRepository, AuthorRepository>();
        // services.AddScoped<ICategoryRepository, CategoryRepository>();
        // services.AddScoped<ICommentRepository, CommentRepository>();
        // services.AddScoped<ITagRepository, TagRepository>();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreatePostCommand).Assembly));
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreatePostCommand).Assembly));
        return services;
    }
}