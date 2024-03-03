using OnlineStore.Domain.ProductAggregate;

namespace OnlineStore.Domain.CategoryAggregate
{
    public class Category
    {
        public CategoryID ID { get; }
        public bool IsRoot { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CategoryID? ParentCategoryID { get; set; }
        public Category? ParentCategory { get; }
        // public List<Product> Products { get; }
        // public Category(string name, string description) : this(name, description) { }
        public Category(CategoryID id, string name, string description, CategoryID? parentCategoryID)
        {
            ID = id;
            Name = name.Trim();
            Description = description.Trim();
            _ = parentCategoryID;
        }
        public Category()
        {

        }
    }
}
