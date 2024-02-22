using OnlineStore.Domain.CategoryAggregate;

namespace OnlineStore.UseCases.Interfaces.Data
{
    public record CreateCategoryArguments(string Name, string Description, CategoryID? ParentID);
}
