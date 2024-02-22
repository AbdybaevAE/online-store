using OnlineStore.Domain.CategoryAggregate;
using OnlineStore.Shared.Core;

namespace OnlineStore.Domain.ProductAggregate
{
    public class Product : EntityBase, IEntity
    {
        public string Name { get; }
        public string Description { get; }
        public decimal Price { get; }
        public Category Category { get; }
        public Product(string name, string description, decimal price, Category category)
        {
            Name = name;
            Description = description;
            Price = price;
            Category = category;
        }
    }
}
