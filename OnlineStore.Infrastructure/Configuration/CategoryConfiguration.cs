using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Domain.CategoryAggregate;

namespace OnlineStore.Infrastructure.Configuration
{
    public sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.ID);
            builder.Property(c => c.ID).HasConversion(
                categoryID => categoryID.Value,
                value => new CategoryID(value)
            );
            builder.Property(c => c.Name).HasMaxLength(100);
            builder.Property(c => c.Description).HasMaxLength(100);
        }
    }
}
