using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Yummy.Server.Domain;

namespace Yummy.Server.Persistence.EntityTypeConfigurations;

public class DishConfiguration : IEntityTypeConfiguration<Dish>
{
    public void Configure(EntityTypeBuilder<Dish> builder)
    {
        builder.HasKey(dish => dish.Id);

        builder.Property(dish => dish.Name).IsRequired();

        builder.Property(dish => dish.Price).IsRequired();

        builder.Property(dish => dish.Description).HasColumnType("TEXT");

        builder.Property(dish => dish.PercentageDiscount).HasDefaultValue(0.0);

        // FK Category 1 -> * Dish
        builder.HasOne<Category>()
            .WithMany(category => category.Dishes)
            .HasForeignKey(dish => dish.CategoryId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}