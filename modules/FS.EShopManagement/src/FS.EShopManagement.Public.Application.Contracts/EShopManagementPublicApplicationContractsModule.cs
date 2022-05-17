using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace FS.EShopManagement.Public;

[DependsOn(
    typeof(EShopManagementDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
[DependsOn(
    typeof(EasyAbp.EShop.Orders.EShopOrdersApplicationContractsModule),
    typeof(EasyAbp.EShop.Payments.EShopPaymentsApplicationContractsModule),
    typeof(EasyAbp.EShop.Products.EShopProductsApplicationContractsModule),
    typeof(EasyAbp.EShop.Stores.EShopStoresApplicationContractsModule),
    typeof(EasyAbp.PaymentService.PaymentServiceApplicationContractsModule))]
public class EShopManagementPublicApplicationContractsModule : AbpModule
{

}
