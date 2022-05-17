using Volo.Abp.Domain;
using Volo.Abp.Modularity;
using Volo.Abp.TextTemplating.Razor;

namespace FS.Abp.Emailing;

[DependsOn(
    typeof(AbpTextTemplatingRazorModule),
    typeof(AbpDddDomainModule),
    typeof(EmailingDomainSharedModule)
)]
[DependsOn(typeof(Volo.Abp.Emailing.AbpEmailingModule))]
[DependsOn(typeof(Volo.Abp.Caching.AbpCachingModule))]
public class EmailingDomainModule : AbpModule
{

}
