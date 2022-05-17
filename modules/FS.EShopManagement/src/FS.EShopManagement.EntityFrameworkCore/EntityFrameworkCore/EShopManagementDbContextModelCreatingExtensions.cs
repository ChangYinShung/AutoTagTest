using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using EasyAbp.EShop.Orders.EntityFrameworkCore;
using EasyAbp.EShop.Payments.EntityFrameworkCore;
using EasyAbp.EShop.Products.EntityFrameworkCore;
using EasyAbp.EShop.Stores.EntityFrameworkCore;

namespace FS.EShopManagement.EntityFrameworkCore;

public static class EShopManagementDbContextModelCreatingExtensions
{
    public static void ConfigureEShopManagement(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        /* Configure all entities here. Example:

        builder.Entity<Question>(b =>
        {
            //Configure table & schema name
            b.ToTable(EShopManagementDbProperties.DbTablePrefix + "Questions", EShopManagementDbProperties.DbSchema);

            b.ConfigureByConvention();

            //Properties
            b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);

            //Relations
            b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

            //Indexes
            b.HasIndex(q => q.CreationTime);
        });
        */
        builder.ConfigureEShopOrders();
        builder.ConfigureEShopPayments();
        builder.ConfigureEShopProducts();
        builder.ConfigureEShopStores();
    }
}
