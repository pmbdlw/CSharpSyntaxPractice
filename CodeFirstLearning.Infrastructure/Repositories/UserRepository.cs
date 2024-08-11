using CodeFirstLearning.Domain.Entities;
using CodeFirstLearning.Infrastructure.Data;

namespace CodeFirstLearning.Infrastructure.Repositories;

public class UserRepository(PostDbContext context) : Repository<User>(context), IUserRepository
{
}