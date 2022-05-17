using Volo.Abp.Modularity;

namespace FS.LineNotify.HttpClient;

[DependsOn(
    typeof(FS.LineNotify.LineNotifyCoreModule)
)]
public class LineNotifyHttpClientModule : AbpModule
{

}
