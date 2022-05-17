using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace FS.EShopManagement.Admin;

[DependsOn(
    typeof(EShopManagementDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
[DependsOn(
    typeof(EasyAbp.EShop.Orders.EShopOrdersApplicationContractsModule),
    typeof(EasyAbp.EShop.Payments.EShopPaymentsApplicationContractsModule),
    typeof(EasyAbp.EShop.Products.EShopProductsApplicationContractsModule)
    )]
public class EShopManagementAdminApplicationContractsModule : AbpModule
{

}
