using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;

namespace FS.LineNotify;

[DependsOn(typeof(FS.LineNotify.LineNotifyCoreModule))]
[DependsOn(
    typeof(AbpAspNetCoreMvcModule))]
public class LineNotifyHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(LineNotifyHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        //Configure<AbpLocalizationOptions>(options =>
        //{
        //    options.Resources
        //        .Get<LineNotifyResource>()
        //        .AddBaseTypes(typeof(AbpUiResource));
        //});
    }
}
