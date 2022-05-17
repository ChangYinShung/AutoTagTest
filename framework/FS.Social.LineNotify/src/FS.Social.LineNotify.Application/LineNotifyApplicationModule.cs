using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace FS.Social.LineNotify;

[DependsOn(
    typeof(LineNotifyDomainModule),
    typeof(LineNotifyApplicationContractsModule)
    )]
[DependsOn(typeof(FS.Social.SocialApplicationModule))]
public class LineNotifyApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<LineNotifyApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<LineNotifyApplicationModule>(validate: true);
        });
    }
}
