using OnlineStore.Domain.CategoryAggregate;

namespace OnlineStore.UseCases.Interfaces.Data
{
    public record CategoryResult(CategoryID CategoryID, string CategoryName, string CategoryDescription, CategoryID? ParentCategoryID);
}
