using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace FS.Entity;

[DependsOn(
    typeof(EntityDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
[DependsOn(typeof(Volo.Abp.FluentValidation.AbpFluentValidationModule))]
public class EntityApplicationContractsModule : AbpModule
{

}
