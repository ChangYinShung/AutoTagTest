using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace FS.FormManagement
{

    [DependsOn(
        typeof(FormManagementDomainModule),
        typeof(FormManagementApplicationContractsModule),
        typeof(AbpDddApplicationModule),
        typeof(AbpAutoMapperModule)
        )]
    [DependsOn(typeof(Volo.Forms.FormsApplicationModule))]
    [DependsOn(typeof(Volo.Abp.FluentValidation.AbpFluentValidationModule))]
    public class FormManagementApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<FormManagementApplicationModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<FormManagementApplicationModule>(validate: false);
            });
        }
    }
}