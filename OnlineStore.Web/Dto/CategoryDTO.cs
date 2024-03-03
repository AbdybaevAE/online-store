namespace OnlineStore.Web.Dto
{
    public class CategoryDTO
    {
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public string? ParentCategoryID { get; set; }
    }
}
