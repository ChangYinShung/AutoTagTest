using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace FS.Social.LineNotify;

[DependsOn(
    typeof(LineNotifyDomainSharedModule)
    )]
[DependsOn(typeof(FS.Social.SocialApplicationContractsModule))]
public class LineNotifyApplicationContractsModule : AbpModule
{

}
