﻿using OnlineStore.Domain.ProductAggregate;

namespace OnlineStore.Domain.CategoryAggregate
{
    public class Category
    {
        public bool IsRoot { get; }
        public CategoryID ID { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CategoryID? ParentCategoryID { get; set; }
        public Category? ParentCategory { get; }
        public List<Product> Products { get; }
        // public Category(string name, string description) : this(name, description) { }
        public Category(string name, string description, CategoryID? parentCategoryID)
        {
            Name = name.Trim();
            Description = description.Trim();
            _ = parentCategoryID;
        }
    }
}
