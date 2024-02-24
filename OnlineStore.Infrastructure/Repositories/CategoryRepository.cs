using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.CategoryAggregate;
using OnlineStore.Domain.Interfaces;
using OnlineStore.Infrastructure.Data;

namespace OnlineStore.Infrastructure.Repositories
{
    public class CategoryRepository(AppDbContext dbContext) : RepositoryBase<Category>(dbContext), ICategoryRepository { }
}
