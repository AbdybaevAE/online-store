using OnlineStore.Domain.CategoryAggregate;

namespace OnlineStore.UseCases.Interfaces.Data
{
    public record UpdateCategoryArguments(CategoryID CategoryID, string Name, string Description, CategoryID? ParentCategoryID);
}
