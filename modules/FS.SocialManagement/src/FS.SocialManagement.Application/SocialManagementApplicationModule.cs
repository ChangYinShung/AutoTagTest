using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace FS.SocialManagement;

[DependsOn(typeof(FS.Social.SocialApplicationModule))]
[DependsOn(
    typeof(SocialManagementDomainModule),
    typeof(SocialManagementApplicationContractsModule)
    )]
public class SocialManagementApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<SocialManagementApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<SocialManagementApplicationModule>(validate: false);
        });
    }
}
