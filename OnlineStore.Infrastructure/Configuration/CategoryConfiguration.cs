using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineStore.Domain.CategoryAggregate;

namespace OnlineStore.Infrastructure.Configuration
{
    public sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {

            builder.ToTable("categories");
            builder.HasKey(c => c.ID);
            builder.Property(c => c.ID)
                .HasColumnName("category_id")
                .HasConversion(
                    categoryID => categoryID.Value,
                    value => new CategoryID(value)
                );
            builder.Ignore(c => c.IsRoot);
            builder.Property(c => c.ParentCategoryID)
                .HasColumnName("category_parent_id")
                .HasConversion(
                    parentCategoryID => parentCategoryID!.Value,
                    value => new CategoryID(value)
                );
            builder.Property(c => c.Name)
                .HasColumnName("category_name")
                .HasMaxLength(100);
            builder.Property(c => c.Description)
                .HasColumnName("category_description")
                .HasMaxLength(100);
        }
    }
}
