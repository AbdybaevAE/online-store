using OnlineStore.Domain.CategoryAggregate;

namespace OnlineStore.UseCases.Interfaces.Data
{
    public class CategoryResult
    {
        public CategoryID CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public CategoryID? ParentCategoryID { get; set; }
    }
}
