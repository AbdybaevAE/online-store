using OnlineStore.UseCases.Interfaces.Data;

namespace OnlineStore.UseCases.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryResult> CreateCategory(CreateCategoryArguments arguments, CancellationToken cancellationToken);
        Task DeleteCategory(DeleteCategoryArguments arguments, CancellationToken cancellationToken);
        Task UpdateCategory(UpdateCategoryArguments arguments, CancellationToken cancellationToken);
        Task<IEnumerable<CategoryResult>> GetAllCategories(CancellationToken cancellationToken);
    }
}
