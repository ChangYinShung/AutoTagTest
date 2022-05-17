using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace FS.EntityManagement
{
    [DependsOn(
    typeof(EntityManagementDomainModule),
    typeof(EntityManagementApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule)
    )]
    [DependsOn(typeof(FS.Entity.EntityDefaults.EntityDefaultsApplicationModule))]
    public class EntityManagementApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<EntityManagementApplicationModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<EntityManagementApplicationModule>(validate: false);
            });
        }
    }
}


