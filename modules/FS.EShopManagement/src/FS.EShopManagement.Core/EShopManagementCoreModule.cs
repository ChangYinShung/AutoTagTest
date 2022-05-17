using Volo.Abp.Modularity;

namespace FS.EShopManagement;

[DependsOn(typeof(FS.Abp.AutoFilterer.AbpAutoFiltererCoreModule))]
[DependsOn(typeof(FS.Abp.MediatR.AbpMediatRCoreModule))]
public class EShopManagementCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
       
    }
}
