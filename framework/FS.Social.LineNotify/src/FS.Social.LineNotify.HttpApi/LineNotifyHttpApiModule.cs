using Volo.Abp.Modularity;

namespace FS.Social.LineNotify;

[DependsOn(
    typeof(LineNotifyApplicationContractsModule))]
[DependsOn(typeof(FS.LineNotify.LineNotifyHttpApiModule))]
public class LineNotifyHttpApiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {

    }
}
