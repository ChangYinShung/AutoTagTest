using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace FS.CmsKitManagement
{
    [DependsOn(
        typeof(CmsKitManagementDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    [DependsOn(typeof(Volo.CmsKit.CmsKitApplicationContractsModule))]
    [DependsOn(
        typeof(FS.CmsKit.ContentDefinitions.ContentDefinitionsApplicationContractsModule),
        typeof(FS.CmsKit.ContentComposites.ContentCompositesApplicationContractsModule)
        )]
    public class CmsKitManagementApplicationContractsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
        }
    }
}
