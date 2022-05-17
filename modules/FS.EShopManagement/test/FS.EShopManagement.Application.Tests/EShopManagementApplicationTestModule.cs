using Volo.Abp.Modularity;

namespace FS.EShopManagement;

[DependsOn(
    typeof(EShopManagementApplicationModule),
    typeof(EShopManagementDomainTestModule)
    )]
public class EShopManagementApplicationTestModule : AbpModule
{

}
