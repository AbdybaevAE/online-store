using OnlineStore.Domain.SharedKernel;

namespace OnlineStore.Domain.Categories
{
    public class CategoryAggregate : IRootAggregate
    {
        public string Name { get; }
        public string Description { get; }
        public CategoryAggregate(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}