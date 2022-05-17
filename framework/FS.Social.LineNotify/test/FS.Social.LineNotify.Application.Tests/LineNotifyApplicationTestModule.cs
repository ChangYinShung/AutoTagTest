using Volo.Abp.Modularity;

namespace FS.Social.LineNotify;

[DependsOn(
    typeof(LineNotifyApplicationModule),
    typeof(LineNotifyDomainTestModule)
    )]
public class LineNotifyApplicationTestModule : AbpModule
{

}
