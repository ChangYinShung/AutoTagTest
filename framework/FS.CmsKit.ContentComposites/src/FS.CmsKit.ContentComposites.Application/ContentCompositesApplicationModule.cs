using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace FS.CmsKit.ContentComposites;

[DependsOn(
    typeof(ContentCompositesDomainModule),
    typeof(ContentCompositesApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule)
    )]
[DependsOn(typeof(Volo.Abp.FluentValidation.AbpFluentValidationModule))]
public class ContentCompositesApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<ContentCompositesApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<ContentCompositesApplicationModule>(validate: false);
        });
    }
}
