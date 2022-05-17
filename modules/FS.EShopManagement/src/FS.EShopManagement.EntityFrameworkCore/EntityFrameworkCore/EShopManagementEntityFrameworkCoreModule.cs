using EasyAbp.EShop.Products.Products;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace FS.EShopManagement.EntityFrameworkCore;

[DependsOn(
    typeof(EShopManagementDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
[DependsOn(
    typeof(EasyAbp.EShop.Orders.EntityFrameworkCore.EShopOrdersEntityFrameworkCoreModule),
    typeof(EasyAbp.EShop.Payments.EntityFrameworkCore.EShopPaymentsEntityFrameworkCoreModule),
    typeof(EasyAbp.EShop.Products.EntityFrameworkCore.EShopProductsEntityFrameworkCoreModule),
    typeof(EasyAbp.EShop.Stores.EntityFrameworkCore.EShopStoresEntityFrameworkCoreModule)
    )]
public class EShopManagementEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<EShopManagementDbContext>(options =>
        {
            /* Add custom repositories here. Example:
             * options.AddRepository<Question, EfCoreQuestionRepository>();
             */
            options.AddRepository<ProductView, ProductViewRepository>();
        });
    }
}
