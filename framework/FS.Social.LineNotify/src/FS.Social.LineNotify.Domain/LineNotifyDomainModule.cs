using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace FS.Social.LineNotify;

[DependsOn(typeof(FS.LineNotify.LineNotifyCoreModule))]
[DependsOn(typeof(FS.Social.SocialDomainModule))]
[DependsOn(
    typeof(LineNotifyDomainSharedModule)
)]
public class LineNotifyDomainModule : AbpModule
{

}
