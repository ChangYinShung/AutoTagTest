using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace FS.CmsKit;

[DependsOn(
    typeof(CmsKitDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
[DependsOn(typeof(Volo.Abp.FluentValidation.AbpFluentValidationModule))]
public class CmsKitApplicationContractsModule : AbpModule
{

}
