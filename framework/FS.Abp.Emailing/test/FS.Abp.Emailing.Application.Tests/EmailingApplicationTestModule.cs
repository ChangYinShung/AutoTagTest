using Volo.Abp.Modularity;

namespace FS.Abp.Emailing;

[DependsOn(
    typeof(EmailingApplicationModule),
    typeof(EmailingDomainTestModule)
    )]
public class EmailingApplicationTestModule : AbpModule
{

}
