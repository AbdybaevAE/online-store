using OnlineStore.Domain.CategoryAggregate;
using OnlineStore.UseCases.Interfaces.Data;

namespace OnlineStore.UseCases.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryResult> CreateCategory(CreateCategoryArguments arguments, CancellationToken cancellationToken);
        Task DeleteCategory(CategoryID categoryID, CancellationToken cancellationToken);
        Task UpdateCategory(UpdateCategoryArguments arguments, CancellationToken cancellationToken);
        Task<IEnumerable<CategoryResult>> GetAllCategories(CancellationToken cancellationToken);
        Task<CategoryResult> GetCategoryByID(CategoryID categoryID, CancellationToken cancellationToken);
    }
}
