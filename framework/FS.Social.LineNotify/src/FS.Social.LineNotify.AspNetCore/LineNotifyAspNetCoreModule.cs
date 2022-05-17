using Localization.Resources.AbpUi;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace FS.Social.LineNotify;

[DependsOn(
    typeof(LineNotifyApplicationModule),
    typeof(LineNotifyHttpApiModule))]
[DependsOn(typeof(FS.LineNotify.HttpClient.LineNotifyHttpClientModule))]
public class LineNotifyAspNetCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAspNetCoreMvcOptions>(options =>
        {
            options.ConventionalControllers.Create(typeof(LineNotifyApplicationModule).Assembly, optionsAction =>
             {
                 optionsAction.RootPath=SocialRemoteServiceConsts.ModuleName;
                 optionsAction.RemoteServiceName=SocialRemoteServiceConsts.RemoteServiceName;
             });
        });
    }
}
